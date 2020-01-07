namespace ExBuddy.Navigation
{
	using Buddy.Coroutines;
	using Clio.Utilities;
	using ExBuddy.Helpers;
	using ExBuddy.Interfaces;
	using ExBuddy.Logging;
	using ff14bot;
	using ff14bot.Behavior;
	using ff14bot.Interfaces;
	using ff14bot.Managers;
	using ff14bot.Navigation;
	using ff14bot.NeoProfiles;
	using ff14bot.Settings;
	using System;
	using System.Diagnostics;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Media;

	public class FlightEnabledSlideMover : LogColors, IFlightEnabledPlayerMover
	{
		private static Func<Vector3, bool> shouldFlyToFunc = ShouldFlyInternal;

		private readonly Stopwatch landingStopwatch = new Stopwatch();

		protected readonly Logger Logger;

		private readonly Stopwatch takeoffStopwatch = new Stopwatch();

		private readonly Stopwatch totalLandingStopwatch = new Stopwatch();

		private bool disposed;

		internal bool IsMovingTowardsLocation;

		private Task landingTask;

		private object landingTaskLock = new object();

		private object takeoffTaskLock = new object();

		private Task takeoffTask;

		public FlightEnabledSlideMover(IPlayerMover innerMover, bool forceLanding = false)
			: this(innerMover, new FlightMovementArgs { ForceLanding = forceLanding }) { }

		public FlightEnabledSlideMover(IPlayerMover innerMover, IFlightMovementArgs flightMovementArgs)
		{
			if (flightMovementArgs == null)
			{
				throw new NullReferenceException("flightMovementArgs is null");
			}

			Logger = new Logger(this);
			InnerMover = innerMover;
			Navigator.PlayerMover = this;
			FlightMovementArgs = flightMovementArgs;

			GameEvents.OnMapChanged += GameEventsOnMapChanged;
		}

		public override Color Info
		{
			get { return Colors.LightSkyBlue; }
		}

		public IPlayerMover InnerMover { get; set; }

		protected internal bool ShouldFly { get; private set; }

		#region IDisposable Members

		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				Navigator.PlayerMover = InnerMover;
				GameEvents.OnMapChanged -= GameEventsOnMapChanged;
			}
		}

		#endregion IDisposable Members

		public void EnsureFlying()
		{
			if (!MovementManager.IsFlying && ActionManager.CanMount == 0)
			{
				if (!takeoffStopwatch.IsRunning)
				{
					takeoffStopwatch.Restart();
				}

				if (takeoffTask == null)
				{
					lock (takeoffTaskLock)
					{
						if (takeoffTask == null)
						{
							Logger.Info(Localization.Localization.FlightEnabledSlideMover_TakeoffStart);
							takeoffTask = Task.Factory.StartNew(
                                () =>
								{
									try
									{
										Coroutine coroutine = null;
										while (!MovementManager.IsFlying && Behaviors.ShouldContinue && IsMovingTowardsLocation)
										{
											if (takeoffStopwatch.ElapsedMilliseconds > 10000)
											{
												Logger.Error(Localization.Localization.FlightEnabledSlideMover_TakeoffFailed);
												InnerMover.MoveStop();
												IsTakingOff = false;
												return;
										    }

										    if (coroutine == null || coroutine.IsFinished)
										    {
										        Logger.Verbose(Localization.Localization.FlightEnabledSlideMover_TakeoffNew);
										        coroutine = new Coroutine(async () => await CommonTasks.TakeOff());
										    }

                                            if (!coroutine.IsFinished && !MovementManager.IsFlying && Behaviors.ShouldContinue)
										    {
										        Logger.Verbose(Localization.Localization.FlightEnabledSlideMover_TakeoffResumed);
										        coroutine.Resume();
										    }

                                            Thread.Sleep(66);
										}
									}
									finally
									{
										if (!IsMovingTowardsLocation)
										{
											Logger.Warn(Localization.Localization.FlightEnabledSlideMover_TakeoffCancelled, takeoffStopwatch.Elapsed);
										}
										else
										{
											Logger.Info(Localization.Localization.FlightEnabledSlideMover_Takeoff, takeoffStopwatch.Elapsed);
										}

										takeoffStopwatch.Reset();
										IsTakingOff = false;
										takeoffTask = null;
									}
								});
						}
					}
				}
			}
			else
			{
				IsTakingOff = false;
			}
		}

		public void ForceLanding()
		{
			if (!IsDiving && MovementManager.IsFlying)
			{
				Logger.Info("Landing Task Started: {0} {1}", IsDiving, MovementManager.IsFlying);

				if (!landingStopwatch.IsRunning)
				{
					landingStopwatch.Restart();
				}

				if (!totalLandingStopwatch.IsRunning)
				{
					totalLandingStopwatch.Restart();
				}

				if (landingTask == null)
				{
					lock (landingTaskLock)
					{
						if (landingTask == null)
						{
							Logger.Info(Localization.Localization.FlightEnabledSlideMover_LandStart);
							landingTask = Task.Factory.StartNew(
								() =>
								{
									Coroutine landingCoroutine = null;
									try
									{
										//the landingCoroutine might not be disposed of properly if the user should change zones or stop the bot.
										//let's shut it down for them.
										while (!IsDiving && MovementManager.IsFlying && Behaviors.ShouldContinue && !IsMovingTowardsLocation && TreeRoot.IsRunning)
										{
											if (landingStopwatch.ElapsedMilliseconds < 2000)
											{
												// TODO: possible check to see if floor is more than 80 or 100 below us to not bother? or check for last destination and compare the Y value of the floor.
												MovementManager.StartDescending();
											}
											else
											{
												if (totalLandingStopwatch.ElapsedMilliseconds > 10000)
												{
													Logger.Error(Localization.Localization.FlightEnabledSlideMover_LandFailed);
													InnerMover.MoveStop();
													return;
												}

												if (landingCoroutine == null || landingCoroutine.IsFinished)
												{
													var move = Core.Player.Location.AddRandomDirection2D(10).GetFloor(8);
													MovementManager.StopDescending();
													MovementManager.Jump();
												    landingCoroutine = new Coroutine(async () => await move.MoveToNoMount(false, 0.8f));
                                                    Logger.Info(Localization.Localization.FlightEnabledSlideMover_LandNew, move);
												}

												if (!landingCoroutine.IsFinished && MovementManager.IsFlying && !IsDiving)
												{
													Logger.Verbose(Localization.Localization.FlightEnabledSlideMover_LandResumed);
													while (!IsDiving && !landingCoroutine.IsFinished && MovementManager.IsFlying && Behaviors.ShouldContinue
														   && !IsMovingTowardsLocation && TreeRoot.IsRunning)
													{
														landingCoroutine.Resume();
														Thread.Sleep(66);
													}
												}

												if (MovementManager.IsFlying && !IsDiving)
												{
													landingStopwatch.Restart();
												}
											}

											Thread.Sleep(33);
										}
									}
									finally
									{
										MovementManager.StopDescending();
										if (IsMovingTowardsLocation)
										{
											Logger.Warn(Localization.Localization.FlightEnabledSlideMover_LandCancelled, totalLandingStopwatch.Elapsed);
											InnerMover.MoveStop();
										}
										else
										{
											Logger.Info(Localization.Localization.ExFlyTo_Landing, totalLandingStopwatch.Elapsed);
										}

										totalLandingStopwatch.Reset();
										landingStopwatch.Reset();

										if (Coroutine.Current != landingCoroutine)
										{
											landingCoroutine?.Dispose();
										}
										IsLanding = false;
										landingTask = null;
									}
								});
						}
					}
				}
			}
			else
			{
				IsLanding = false;
			}
		}

		public static explicit operator SlideMover(FlightEnabledSlideMover playerMover)
		{
			return playerMover.InnerMover as SlideMover;
		}

		internal static bool ShouldFlyInternal(Vector3 destination)
		{
			return MovementManager.IsFlying
				   || (ActionManager.CanMount == 0
					   &&
					   ((destination.Distance3D(Core.Me.Location) >=
						 CharacterSettings.Instance.MountDistance)
						|| !destination.IsGround()));
		}

		private void GameEventsOnMapChanged(object sender, EventArgs e)
		{
			ShouldFly = false;
			Logger.Info(Localization.Localization.FlightEnabledSlideMover_Default);
		}

		#region IFlightEnabledPlayerMover Members

		public bool CanFly => WorldManager.CanFly;

		public IFlightMovementArgs FlightMovementArgs { get; set; }

		public bool IsLanding { get; protected set; }

		public bool IsTakingOff { get; protected set; }

		public async Task SetShouldFlyAsync(Task<Func<Vector3, bool>> customShouldFlyToFunc)
		{
			shouldFlyToFunc = await customShouldFlyToFunc;
		}

		public bool ShouldFlyTo(Vector3 destination)
		{
			if (shouldFlyToFunc == null)
			{
				return false;
			}

			return CanFly && (ShouldFly = shouldFlyToFunc(destination));
		}
        
		public bool IsDiving => MovementManager.IsDiving;

		#endregion IFlightEnabledPlayerMover Members

		#region IPlayerMover Members

		public void MoveStop()
		{
			if (!IsLanding)
			{
				InnerMover.MoveStop();
				IsMovingTowardsLocation = false;
			}

			// TODO: Check can land!!
			if (!IsDiving && !IsLanding && (FlightMovementArgs.ForceLanding ||
											GameObjectManager.LocalPlayer.Location.IsGround(4.5f)))
			{
				IsLanding = true;
				ForceLanding();
			}
		}

		public void MoveTowards(Vector3 location)
		{
			if (IsLanding && location.Distance3D(Core.Me.Location) < CharacterSettings.Instance.MountDistance)
			{
				ForceLanding();
				return;
			}
			if (ShouldFly && !MovementManager.IsFlying && !IsTakingOff)
			{
				IsTakingOff = true;
				IsMovingTowardsLocation = true;
				EnsureFlying();
		    }

		    //Logger.Info("IsTakingOff : " + IsTakingOff);

            if (!IsTakingOff)
			{
				IsMovingTowardsLocation = true;
			    //Logger.Info("MoveTowards " + location);
                InnerMover.MoveTowards(location);
			}
		}

		#endregion IPlayerMover Members
	}
}