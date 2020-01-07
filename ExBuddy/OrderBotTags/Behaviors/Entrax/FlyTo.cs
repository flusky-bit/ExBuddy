// ReSharper disable once CheckNamespace

namespace ExBuddy.OrderBotTags.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Clio.Utilities;
    using Clio.XmlEngine;
    using ff14bot;
    using ff14bot.Behavior;
    using ff14bot.Helpers;
    using ff14bot.Managers;
    using ff14bot.Navigation;
    using ff14bot.Pathing;

    [XmlElement("EtxFlyTo")]
    public class EtxFlyTo : ExProfileBehavior
    {
        [XmlAttribute("XYZ")]
        public Vector3 XYZ { get; set; }

        [DefaultValue(7.0f)]
        [XmlAttribute("AllowedVariance")]
        public float AllowedVariance { get; set; }

        [DefaultValue(1.5f)]
        [XmlAttribute("ArrivalTolerance")]
        public float ArrivalTolerance { get; set; }

        [DefaultValue(0f)]
        [XmlAttribute("MinHeight")]
        public float MinHeight { get; set; }

        [XmlElement("DestinationChoices")]
        public List<HotSpot> Hotspots { get; set; }

        [DefaultValue(false)]
        [XmlAttribute("Land")]
        public bool Land { get; set; }

        [DefaultValue(false)]
        [XmlAttribute("Dismount")]
        public bool Dismount { get; set; }

        [DefaultValue(false)]
        [XmlAttribute("IgnoreIndoors")]
        public bool IgnoreIndoors { get; set; }

        private Vector3? FinalDestination { get; set; }
        private HotSpot RoughDestination { get; set; }

        public new void Log(string text, params object[] args) { Logger.Mew("[EtxFlyTo] " + string.Format(text, args)); }

        protected override void OnDone() { Navigator.PlayerMover.MoveStop(); }

        protected override async Task<bool> Main()
        {
            var immediateDestination = FindImmediateDestination();

            if (AtLocation(Core.Player.Location, immediateDestination))
            {
                var completionMessage = $"Arrived at destination {RoughDestination.Name}";
                if (Land)
                {
                    Log("Landing at destination {0}", RoughDestination.Name);
                    var landed = await CommonTasks.Land();
                    if (landed)
                    {
                        if (Dismount)
                            ActionManager.Dismount();
                        BehaviorDone(completionMessage);
                        return true;
                    }
                    Log("Failed to land at {0}", immediateDestination);
                    return false;
                }
                BehaviorDone(completionMessage);
                return false;
            }

            var parameters = new FlyToParameters(immediateDestination) {CheckIndoors = !IgnoreIndoors};
            if (MinHeight > 0)
                parameters.MinHeight = MinHeight;

            await CommonTasks.MountUp();
            await CommonTasks.TakeOff();

            Flightor.MoveTo(parameters);
            return true;
        }

        protected bool BehaviorDone(string extraMessage = null)
        {
            if (isDone) return isDone = true;
            Log("{0} behavior complete. {1}", GetType().Name, extraMessage ?? string.Empty);
            return isDone = true;
        }

        private Vector3 FindImmediateDestination()
        {
            if (FinalDestination.HasValue)
                return FinalDestination.Value;

            var distanceToPickVariantDestinationSqr = Math.Max(50.0, RoughDestination.ArrivalTolerance + 10.0);
            distanceToPickVariantDestinationSqr *= distanceToPickVariantDestinationSqr;

            if (!(Core.Player.Location.DistanceSqr(RoughDestination.Position) <= distanceToPickVariantDestinationSqr)) return RoughDestination.Position;
            FinalDestination = RoughDestination.Position.FanOutRandom(RoughDestination.AllowedVariance);
            return FinalDestination.Value;
        }

        private bool AtLocation(Vector3 myPos, Vector3 otherPos)
        {
            if (myPos.Distance2DSqr(otherPos) > RoughDestination.ArrivalTolerance * RoughDestination.ArrivalTolerance)
                return false;

            var yTolerance = Math.Max(4.5f, RoughDestination.ArrivalTolerance);
            return Math.Abs(otherPos.Y - myPos.Y) < yTolerance;
        }

        protected override void OnStart()
        {
            if (Hotspots != null && Hotspots.Count > 0)
            {
                var choice = Core.Random.Next(0, Hotspots.Count);
                RoughDestination = Hotspots[choice];
            }
            else
            {
                RoughDestination = new HotSpot(XYZ, 0) {AllowedVariance = AllowedVariance, ArrivalTolerance = ArrivalTolerance};
            }
        }

        protected override void DoReset()
        {
            RoughDestination = null;
            FinalDestination = null;
        }
    }
}