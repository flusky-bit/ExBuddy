﻿namespace ExBuddy.OrderBotTags.Gather
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Media;

    using Buddy.Coroutines;

    using Clio.Utilities;
    using Clio.XmlEngine;

    using ExBuddy.Attributes;
    using ExBuddy.Enums;
    using ExBuddy.Helpers;
    using ExBuddy.Interfaces;
    using ExBuddy.OrderBotTags.Behaviors;
    using ExBuddy.OrderBotTags.Gather.Rotations;
    using ExBuddy.OrderBotTags.Objects;

    using ff14bot;
    using ff14bot.Behavior;
    using ff14bot.Enums;
    using ff14bot.Helpers;
    using ff14bot.Managers;
    using ff14bot.Navigation;
    using ff14bot.NeoProfiles;
    using ff14bot.Objects;

    using TreeSharp;

    [XmlElement("GatherCollectable")]
    public sealed class GatherCollectableTag : ExProfileBehavior
    {
        internal static readonly Dictionary<string, IGatheringRotation> Rotations;

        // TODO: set this on startup maybe?  was null
        internal static SpellData CordialSpellData = DataManager.GetItem((uint)CordialType.Cordial).BackingAction;

        internal bool MovementStopCallback(float distance, float radius)
        {
            return distance <= radius || !WhileFunc() || Me.IsDead;
        }

        private bool isDone;

        private int loopCount;

        private Func<bool> freeRangeConditionFunc;

        private IGatheringRotation initialGatherRotation;

        private IGatheringRotation gatherRotation;

        internal bool GatherItemIsFallback;

        internal IGatherSpot GatherSpot;

        internal GatheringPointObject Node;

        internal GatheringItem GatherItem;

        internal Collectable CollectableItem;

        internal int NodesGatheredAtMaxGp;

        internal Func<bool> WhileFunc;

        private DateTime startTime;

        private Composite poiCoroutine;

        private bool interactedWithNode;

        static GatherCollectableTag()
        {
            Rotations = LoadRotationTypes();
        }

        public override bool IsDone
        {
            get
            {
                return isDone;
            }
        }

        public int AdjustedWaitForGp
        {
            get
            {
                var requiredGp = gatherRotation == null ? 0 : gatherRotation.Attributes.RequiredGp;

                // Return the lower of your MaxGP rounded down to the nearest 50.
                return Math.Min(Me.MaxGP - (Me.MaxGP % 50), requiredGp);
            }
        }

        [DefaultValue(true)]
        [XmlAttribute("AlwaysGather")]
        public bool AlwaysGather { get; set; }

        [DefaultValue(CordialTime.IfNeeded)]
        [XmlAttribute("CordialTime")]
        public CordialTime CordialTime { get; set; }

        [DefaultValue(CordialType.None)]
        [XmlAttribute("CordialType")]
        public CordialType CordialType { get; set; }

        [XmlAttribute("DiscoverUnknowns")]
        public bool DiscoverUnknowns { get; set; }

        [XmlAttribute("FreeRange")]
        public bool FreeRange { get; set; }

        [DefaultValue("Condition.TrueFor(1, TimeSpan.FromHours(1))")]
        [XmlAttribute("FreeRangeCondition")]
        public string FreeRangeCondition { get; set; }

        [XmlElement("GatheringSkillOrder")]
        public GatheringSkillOrder GatheringSkillOrder { get; set; }

        [DefaultValue(3.0f)]
        [XmlAttribute("Radius")]
        public float Radius { get; set; }

        // I want this to be an attribute, but for backwards compatibilty, we will use element
        [DefaultValue(-1)]
        [XmlElement("Slot")]
        public int Slot { get; set; }

        // Backwards compatibility
        [XmlElement("GatherObject")]
        public string GatherObject { get; set; }

        [XmlElement("GatherObjects")]
        public List<string> GatherObjects { get; set; }

        [XmlAttribute("DisableRotationOverride")]
        public bool DisableRotationOverride { get; set; }

        // Maybe this should be an attribute?
        [DefaultValue("RegularNode")]
        [XmlElement("GatherRotation")]
        public string GatherRotation { get; set; }

        [XmlElement("GatherSpots")]
        public List<StealthApproachGatherSpot> GatherSpots { get; set; }

        [DefaultValue(GatherIncrease.Auto)]
        [XmlAttribute("GatherIncrease")]
        public GatherIncrease GatherIncrease { get; set; }

        [DefaultValue(GatherStrategy.GatherOrCollect)]
        [XmlAttribute("GatherStrategy")]
        public GatherStrategy GatherStrategy { get; set; }

        [XmlElement("HotSpots")]
        public IndexedList<HotSpot> HotSpots { get; set; }

        [XmlElement("Collectables")]
        public List<Collectable> Collectables { get; set; }

        [XmlElement("ItemNames")]
        public List<string> ItemNames { get; set; }

        [DefaultValue(3.1f)]
        [XmlAttribute("Distance")]
        public float Distance { get; set; }

        [XmlAttribute("SkipWindowDelay")]
        public uint SkipWindowDelay { get; set; }

        [XmlAttribute("SpellDelay")]
        public int SpellDelay { get; set; }

        [DefaultValue(2000)]
        [XmlAttribute("WindowDelay")]
        public int WindowDelay { get; set; }

        [DefaultValue(-1)]
        [XmlAttribute("Loops")]
        public int Loops { get; set; }

        [XmlAttribute("SpawnTimeout")]
        public int SpawnTimeout { get; set; }

        [DefaultValue("True")]
        [XmlAttribute("While")]
        public string While { get; set; }

        // TODO: Look into making this use Type instead of Enum
        [DefaultValue(GatherSpotType.GatherSpot)]
        [XmlAttribute("DefaultGatherSpotType")]
        public GatherSpotType DefaultGatherSpotType { get; set; }

        private bool HandleCondition()
        {
            if (WhileFunc == null)
            {
                WhileFunc = ScriptManager.GetCondition(While);
            }

            // If statement is true, return false so we can continue the routine
            if (WhileFunc())
            {
                return false;
            }

            isDone = true;
            return true;
        }

        protected override void OnResetCachedDone()
        {
            if (!isDone)
            {
                Logging.Write(Colors.Chartreuse, "GatherCollectable: Resetting.");
            }

            interactedWithNode = false;
            isDone = false;
            loopCount = 0;
            NodesGatheredAtMaxGp = 0;
            ResetInternal();
        }

        internal void ResetInternal()
        {
            GatherSpot = null;
            Node = null;
            GatherItem = null;
            CollectableItem = null;
        }

        protected override void OnStart()
        {
            if (FreeRange)
            {
                // Until we find a better way to do it.
                Condition.AddNamespacesToScriptManager("ExBuddy", "ExBuddy.Helpers");
            }

            SpellDelay = SpellDelay < 0 ? 0 : SpellDelay;
            WindowDelay = WindowDelay < 500 ? 500 : WindowDelay;

            if (Distance > 3.5f)
            {
                TreeRoot.Stop("Using a distance of greater than 3.5 is not supported, change the value and restart the profile.");
            }

            if (HotSpots != null)
            {
                HotSpots.IsCyclic = Loops < 1;
            }

            // backwards compatibility
            if (GatherObjects == null && !string.IsNullOrWhiteSpace(GatherObject))
            {
                GatherObjects = new List<string> { GatherObject };
            }

            startTime = DateTime.Now;

            if (CordialSpellData == null)
            {
                CordialSpellData = DataManager.GetItem((uint)CordialType.Cordial).BackingAction;
            }

            poiCoroutine = new ActionRunCoroutine(ctx => ExecutePoiLogic());
            TreeHooks.Instance.AddHook("PoiAction", poiCoroutine);
        }

        protected override void OnDone()
        {
            TreeHooks.Instance.RemoveHook("PoiAction", poiCoroutine);
        }

        protected override Composite CreateBehavior()
        {
            return new ActionRunCoroutine(ctx => Main());
        }

        private async Task<bool> Main()
        {
            await CommonTasks.HandleLoading();

            return HandleDeath()
                || HandleCondition()
                || await CastTruth()
                || HandleReset()
                || await MoveToHotSpot()
                || await FindNode()
                || await ResetOrDone();
        }

        private async Task<bool> ExecutePoiLogic()
        {
            if (Poi.Current.Type != PoiType.Gather)
            {
                return false;
            }

            var result = FindGatherSpot()
                || ResolveGatherRotation()
                || await GatherSequence();

            if (!result)
            {
                Poi.Clear("Something happened during gathering and we did not complete the sequence");    
            }

            if (Poi.Current.Type == PoiType.Gather && (!Poi.Current.Unit.IsValid || !Poi.Current.Unit.IsVisible))
            {
                Poi.Clear("Node is gone");
            }

            return result;
        }

        private bool HandleDeath()
        {
            if (Me.IsDead && Poi.Current.Type != PoiType.Death)
            {
                Poi.Current = new Poi(Me, PoiType.Death);
                return true;
            }

            return false;
        }

        private async Task<bool> GatherSequence()
        {
            return await MoveToGatherSpot()
                && await BeforeGather()
                && await Gather()
                && await AfterGather()
                && await MoveFromGatherSpot();
        }

        private bool HandleReset()
        {
            if (Node == null || (Node.IsValid && (!FreeRange || !(Node.Location.Distance3D(Me.Location) > Radius))))
            {
                return false;
            }

            OnResetCachedDone();
            return true;
        }

        private async Task<bool> MoveToHotSpot()
        {
            if (HotSpots != null && !HotSpots.CurrentOrDefault.WithinHotSpot2D(Me.Location))
            {
                //return lets try not caring if we succeed on the move
                await
                Behaviors.MoveTo(
                    HotSpots.CurrentOrDefault,
                    radius: HotSpots.CurrentOrDefault.Radius * 0.75f,
                    name: HotSpots.CurrentOrDefault.Name,
                    stopCallback: MovementStopCallback);

                startTime = DateTime.Now;
                return true;
            }

            return false;
        }

        private static Dictionary<string, IGatheringRotation> LoadRotationTypes()
        {
            Type[] types = null;
            try
            {
                types =
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => !t.IsAbstract && typeof(IGatheringRotation).IsAssignableFrom(t) && t.GetCustomAttribute<GatheringRotationAttribute>() != null)
                        .ToArray();
            }
            catch
            {
                Logging.Write("Unable to get types, Loading Known Rotations.");
            }

            if (types == null)
            {
                types = GetKnownRotationTypes();
            }

            ReflectionHelper.CustomAttributes<GatheringRotationAttribute>.RegisterTypes(types);

            var instances = types.Select(t => t.CreateInstance<IGatheringRotation>()).ToArray();

            foreach (var instance in instances)
            {
                Logging.Write(
                    Colors.Chartreuse,
                    "GatherCollectable: Loaded Rotation -> {0}, GP: {1}, Time: {2}",
                    instance.Attributes.Name,
                    instance.Attributes.RequiredGp,
                    instance.Attributes.RequiredTimeInSeconds);
            }


            var dict =
                instances.ToDictionary(
                    k => k.Attributes.Name, v => v, StringComparer.InvariantCultureIgnoreCase);

            return dict;

        }

        private static Type[] GetKnownRotationTypes()
        {
            return new[]
                       {
                            typeof(RegularNodeGatheringRotation),
                            typeof(UnspoiledGatheringRotation) ,
                            typeof(DefaultCollectGatheringRotation),
                            typeof(Collect115GatheringRotation),
                            typeof(Collect345GatheringRotation),
                            typeof(Collect450GatheringRotation),
                            typeof(Collect470GatheringRotation),
                            typeof(Collect550GatheringRotation),
                            typeof(Collect570GatheringRotation),
                            typeof(DiscoverUnknownsGatheringRotation),
                            typeof(ElementalGatheringRotation),
                            typeof(TopsoilGatheringRotation),
                            typeof(MapGatheringRotation),
                            typeof(SmartQualityGatheringRotation),
                            typeof(SmartYieldGatheringRotation),
                            typeof(YieldAndQualityGatheringRotation),
                            typeof(NewbCollectGatheringRotation)
                       };
        }

        private bool ResolveGatherRotation()
        {
            if (gatherRotation != null)
            {
                return false;
            }

            if (GatheringSkillOrder != null && GatheringSkillOrder.GatheringSkills.Count > 0)
            {
                initialGatherRotation = gatherRotation = new GatheringSkillOrderGatheringRotation();

                Logging.Write(Colors.Chartreuse, "GatherCollectable: Using rotation -> " + gatherRotation.Attributes.Name);
            }

            IGatheringRotation rotation;
            if (!Rotations.TryGetValue(GatherRotation, out rotation))
            {
                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (!Rotations.TryGetValue("RegularNode", out rotation))
                {
                    rotation = new RegularNodeGatheringRotation();
                }
                else
                {
                    rotation = Rotations["RegularNode"];
                }

                Logging.Write(Colors.PaleVioletRed, "GatherCollectable: Could not find rotation, using RegularNode instead.");
            }

            initialGatherRotation = gatherRotation = rotation;

            Logging.Write(Colors.Chartreuse, "GatherCollectable: Using rotation -> " + rotation.Attributes.Name);

            return true;
        }

        private async Task<bool> CastTruth()
        {
            if (Me.CurrentJob != ClassJobType.Miner && Me.CurrentJob != ClassJobType.Botanist)
            {
                return false;
            }

            if (MovementManager.IsFlying
                || Me.ClassLevel < 46
                || Me.HasAura((int)
                        (Me.CurrentJob == ClassJobType.Miner
                             ? AbilityAura.TruthOfMountains
                             : AbilityAura.TruthOfForests)))
            {
                return false;
            }

            while (Me.IsMounted && Behaviors.ShouldContinue)
            {
                await CommonTasks.StopAndDismount();
                await Coroutine.Yield();
            }

            return await
                CastAura(
                    Ability.Truth,
                    Me.CurrentJob == ClassJobType.Miner ? AbilityAura.TruthOfMountains : AbilityAura.TruthOfForests);
        }

        private async Task<bool> ResetOrDone()
        {
            while (Me.InCombat && Behaviors.ShouldContinue)
            {
                await Coroutine.Yield();
            }

            if (!FreeRange && (HandleDeath() || HotSpots == null || HotSpots.Count == 0 || (Node != null && IsUnspoiled() && interactedWithNode)))
            {
                isDone = true;
            }
            else
            {
                ResetInternal();
            }

            return true;
        }

        private bool ChangeHotSpot()
        {
            if (SpawnTimeout > 0 && DateTime.Now < startTime.AddSeconds(SpawnTimeout))
            {
                return false;
            }

            startTime = DateTime.Now;

            if (HotSpots != null)
            {
                // If finished current loop and set to not cyclic (we know this because if it was cyclic Next is always true)
                if (!HotSpots.Next())
                {
                    Logging.Write(Colors.Chartreuse, "GatherCollectable: Finished {0} of {1} loops.", ++loopCount, Loops);

                    // If finished all loops, otherwise just incrementing loop count
                    if (loopCount == Loops)
                    {
                        isDone = true;
                        return true;
                    }

                    // If not cyclic and it is on the last index
                    if (!HotSpots.IsCyclic && HotSpots.Index == HotSpots.Count - 1)
                    {
                        HotSpots.Index = 0;
                    }
                }
            }

            return true;
        }

        private bool FindGatherSpot()
        {
            if (GatherSpot != null)
            {
                return false;
            }

            if (GatherSpots != null && Node.Location.Distance3D(Me.Location) > Distance)
            {
                GatherSpot = GatherSpots.OrderBy(gs => gs.NodeLocation.Distance3D(Node.Location)).FirstOrDefault(gs => gs.NodeLocation.Distance3D(Node.Location) <= Distance);
            }

            // Either GatherSpots is null, the node is already in range, or there are no matches, use fallback
            if (GatherSpot == null)
            {
                SetFallbackGatherSpot(Node.Location, true);
            }

            Logging.Write(Colors.Chartreuse, "GatherCollectable: GatherSpot set -> " + GatherSpot);

            return true;
        }

        private async Task<bool> FindNode(bool retryCenterHotspot = true)
        {
            if (Node != null)
            {
                return false;
            }

            while (Behaviors.ShouldContinue)
            {
                IEnumerable<GatheringPointObject> nodes = GameObjectManager.GetObjectsOfType<GatheringPointObject>().Where(gpo => gpo.CanGather).ToArray();

                if (GatherStrategy == GatherStrategy.TouchAndGo && HotSpots != null)
                {
                    if (GatherObjects != null)
                    {
                        nodes = nodes.Where(gpo => GatherObjects.Contains(gpo.EnglishName, StringComparer.InvariantCultureIgnoreCase));
                    }

                    foreach (var node in nodes.OrderBy(gpo => gpo.Location.Distance2D(Me.Location)).Where(gpo => HotSpots.CurrentOrDefault.WithinHotSpot2D(gpo.Location)).Skip(1))
                    {
                        if (!Blacklist.Contains(node.ObjectId, BlacklistFlags.Interact))
                        {
                            Blacklist.Add(node, BlacklistFlags.Interact, TimeSpan.FromSeconds(30), "Skip furthest nodes in hotspot. We only want 1.");
                        }
                    }
                }

                nodes = nodes.Where(gpo => !Blacklist.Contains(gpo.ObjectId, BlacklistFlags.Interact));

                if (FreeRange)
                {
                    nodes = nodes.Where(gpo => gpo.Distance2D(Me.Location) < Radius);
                }
                else
                {
                    if (HotSpots != null)
                    {
                        nodes = nodes.OrderBy(gpo => gpo.Location.Distance2D(Me.Location)).Where(gpo => HotSpots.CurrentOrDefault.WithinHotSpot2D(gpo.Location));
                    }
                }

                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (GatherObjects != null)
                {
                    Node = nodes.OrderBy(gpo => GatherObjects.FindIndex(i => string.Equals(gpo.EnglishName, i, StringComparison.InvariantCultureIgnoreCase))).FirstOrDefault(gpo => GatherObjects.Contains(gpo.EnglishName, StringComparer.InvariantCultureIgnoreCase));
                }
                else
                {
                    Node = nodes.FirstOrDefault();
                }

                if (Node == null)
                {
                    if (HotSpots != null)
                    {
                        var myLocation = Me.Location;
                        if (GatherStrategy == GatherStrategy.GatherOrCollect && retryCenterHotspot
                            && GameObjectManager.GameObjects.Select(o => o.Location.Distance2D(myLocation))
                                   .OrderByDescending(o => o).FirstOrDefault() <= myLocation.Distance2D(HotSpots.CurrentOrDefault) + HotSpots.CurrentOrDefault.Radius)
                        {
                            Logging.Write(Colors.PaleVioletRed, "GatherCollectable: Could not find any nodes and can not confirm hotspot is empty via object detection, trying again from center of hotspot.");
                            await Behaviors.MoveTo(
                                HotSpots.CurrentOrDefault,
                                radius: Radius,
                                name: HotSpots.CurrentOrDefault.Name);
                            
                            retryCenterHotspot = false;
                            await Coroutine.Yield();
                            continue;
                        }

                        if (!ChangeHotSpot())
                        {
                            retryCenterHotspot = false;
                            await Coroutine.Yield();
                            continue;
                        }
                    }

                    if (FreeRange && !FreeRangeConditional())
                    {
                        await Coroutine.Yield();
                        isDone = true;
                        return true;
                    }

                    return true;
                }

                var entry = Blacklist.GetEntry(Node.ObjectId);
                if (entry != null && entry.Flags.HasFlag(BlacklistFlags.Interact))
                {
                    Logging.Write(Colors.PaleVioletRed, "Node on blacklist, waiting until we move out of range or it clears.");

                    if (await Coroutine.Wait(entry.Length, () => entry.IsFinished || Node.Location.Distance2D(Me.Location) > Radius))
                    {
                        if (!entry.IsFinished)
                        {
                            Node = null;
                            Logging.Write(Colors.Chartreuse, "GatherCollectable: Node Reset, Reason: Ran out of range");
                            return false;
                        }
                    }

                    Logging.Write(Colors.Chartreuse, "GatherCollectable: Node removed from blacklist.");
                }

                Logging.Write(Colors.Chartreuse, "GatherCollectable: Node set -> " + Node);

                if (HotSpots == null)
                {
                    MovementManager.SetFacing2D(Node.Location);
                }

                if (Poi.Current.Unit != Node)
                {
                    Poi.Current = new Poi(Node, PoiType.Gather);
                }

                return true;
            }

            return true;
        }

        private async Task<bool> MoveToGatherSpot()
        {
            var distance = Poi.Current.Location.Distance3D(Me.Location);
            if (FreeRange)
            {
                while(distance > Distance && distance <= Radius && Behaviors.ShouldContinue)
                {
                    await Coroutine.Yield();
                    distance = Poi.Current.Location.Distance3D(Me.Location);
                }
            }

            return distance <= Distance || await GatherSpot.MoveToSpot(this);
        }

        private async Task<bool> MoveFromGatherSpot()
        {
            return GatherSpot == null ||  await GatherSpot.MoveFromSpot(this);
        }

        private struct TimeToGather
        {
#pragma warning disable 414
            public int EorzeaMinutesTillDespawn;
#pragma warning restore 414

            public int RealSecondsTillStartGathering;

            public int TicksTillStartGathering
            {
                get
                {
                    return RealSecondsTillStartGathering / 3;
                }
            }
        }

        private TimeToGather GetTimeToGather()
        {
            var eorzeaMinutesTillDespawn = (int)byte.MaxValue;
            if (IsUnspoiled())
            {
                if (WorldManager.ZoneId > 350)
                {
                    eorzeaMinutesTillDespawn = 55 - WorldManager.EorzaTime.Minute;
                }
                else
                {
                    // We really don't know how much time is left on the node, but it does have at least the 5 more EM.
                    eorzeaMinutesTillDespawn = 60 - WorldManager.EorzaTime.Minute;
                }

            }

            if (IsEphemeral())
            {
                var hoursFromNow = WorldManager.EorzaTime.AddHours(4);
                var rounded = new DateTime(
                    hoursFromNow.Year,
                    hoursFromNow.Month,
                    hoursFromNow.Day,
                    hoursFromNow.Hour - (hoursFromNow.Hour % 4),
                    0,
                    0);

                eorzeaMinutesTillDespawn = (int)(rounded - WorldManager.EorzaTime).TotalMinutes;
            }

            var realSecondsTillDespawn = eorzeaMinutesTillDespawn * 35 / 12;
            var realSecondsTillStartGathering = realSecondsTillDespawn - gatherRotation.Attributes.RequiredTimeInSeconds;

            return new TimeToGather
                       {
                           EorzeaMinutesTillDespawn = eorzeaMinutesTillDespawn,
                           RealSecondsTillStartGathering = realSecondsTillStartGathering
                       };
        }

        private async Task<bool> BeforeGather()
        {
            if (Me.CurrentGP >= AdjustedWaitForGp)
            {
                return true;
            }

            var ttg = GetTimeToGather();

            if (ttg.RealSecondsTillStartGathering < 1)
            {
                if (gatherRotation.ShouldForceGather)
                {
                    return true;
                }

                Logging.Write("Not enough time to gather");
                // isDone = true;
                return true;
            }

            var gp = Math.Min(Me.CurrentGP + ttg.TicksTillStartGathering * 5, Me.MaxGP);

            if (CordialType <= CordialType.None)
            {
                Logging.Write("Cordial not enabled.  To enable cordial use, add the 'cordialType' attribute with value 'Auto', 'Cordial', or 'HiCordial'");

                if (gatherRotation.ShouldForceGather)
                {
                    return true;
                }

                if (gp >= AdjustedWaitForGp)
                {
                    return await WaitForGpRegain();
                }

                Logging.Write("Not enough time to gather");
                // isDone = true;
                return true;
            }

            if (gatherRotation.ShouldForceGather)
            {
                return true;
            }

            if (gp >= AdjustedWaitForGp && CordialTime.HasFlag(CordialTime.IfNeeded))
            {
                return await WaitForGpRegain();
            }

            if (gp >= AdjustedWaitForGp)
            {
                var gpNeeded = AdjustedWaitForGp - (Me.CurrentGP - (Me.CurrentGP % 5));
                var gpNeededTicks = gpNeeded / 5;
                var gpNeededSeconds = gpNeededTicks * 3;

                if (gpNeededSeconds <= CordialSpellData.Cooldown.TotalSeconds + 3)
                {
                    Logging.WriteDiagnostic(
                        Colors.Chartreuse,
                        "GatherCollectable: GP recovering faster than cordial cooldown, waiting for GP. Seconds: {0}",
                        gpNeededSeconds);

                    // no need to wait for cordial, we will have GP faster
                    return await WaitForGpRegain();
                }
            }

            if (gp + 300 >= AdjustedWaitForGp)
            {
                // If we used the cordial or the CordialType is only Cordial, not Auto or HiCordial, then return
                if (await UseCordial(CordialType.Cordial, ttg.RealSecondsTillStartGathering) || CordialType == CordialType.Cordial)
                {
                    if (gatherRotation.ShouldForceGather)
                    {
                        return true;
                    }

                    return await WaitForGpRegain();
                }
            }

            ttg = GetTimeToGather();
            // Recalculate: could have no time left at this point

            if (ttg.RealSecondsTillStartGathering < 1)
            {
                if (gatherRotation.ShouldForceGather)
                {
                    return true;
                }

                Logging.Write("Not enough GP to gather");
                // isDone = true;
                return true;
            }

            gp = Math.Min(Me.CurrentGP + ttg.TicksTillStartGathering * 5, Me.MaxGP);

            if (gp + 400 >= AdjustedWaitForGp)
            {
                if (await UseCordial(CordialType.HiCordial, ttg.RealSecondsTillStartGathering))
                {
                    if (gatherRotation.ShouldForceGather)
                    {
                        return true;
                    }

                    return await WaitForGpRegain();
                }
            }

            if (gatherRotation.ShouldForceGather)
            {
                return true;
            }

            return await WaitForGpRegain();
        }

        private async Task<bool> WaitForGpRegain()
        {
            var ttg = GetTimeToGather();

            if (ttg.RealSecondsTillStartGathering < 1)
            {
                if (gatherRotation.ShouldForceGather)
                {
                    return true;
                }

                Logging.Write("Not enough time to gather");
                // isDone = true;
                return true;
            }

            if (Me.CurrentGP < AdjustedWaitForGp)
            {
                Logging.Write(
                    "Waiting for GP, Time till node is gone(sec): " + ttg.RealSecondsTillStartGathering + ", Current GP: "
                    + Me.CurrentGP + ", WaitForGP: " + AdjustedWaitForGp);
                await
                Coroutine.Wait(
                    TimeSpan.FromSeconds(ttg.RealSecondsTillStartGathering),
                    () => Me.CurrentGP >= AdjustedWaitForGp || Me.CurrentGP == Me.MaxGP);
            }

            return true;
        }

        private async Task<bool> AfterGather()
        {
            // in case we failed our rotation
            await CloseGatheringWindow();

            if (Me.CurrentGP >= Me.MaxGP - 30)
            {
                NodesGatheredAtMaxGp++;
            }
            else
            {
                NodesGatheredAtMaxGp = 0;
            }

            if (!object.ReferenceEquals(gatherRotation, initialGatherRotation))
            {
                gatherRotation = initialGatherRotation;
                Logging.Write(Colors.Chartreuse, "GatherCollectable: Rotation reset -> " + initialGatherRotation.Attributes.Name);
            }

            if (CordialTime.HasFlag(CordialTime.AfterGather))
            {
                if (CordialType == CordialType.Auto)
                {
                    if (Me.MaxGP - Me.CurrentGP > 550)
                    {
                        if (await UseCordial(CordialType.HiCordial))
                        {
                            return true;
                        }
                    }

                    if (Me.MaxGP - Me.CurrentGP > 390)
                    {
                        if (await UseCordial(CordialType.Cordial))
                        {
                            return true;
                        }
                    }
                }

                if (CordialType == CordialType.HiCordial)
                {
                    if (Me.MaxGP - Me.CurrentGP > 430)
                    {
                        if (await UseCordial(CordialType.HiCordial))
                        {
                            return true;
                        }

                        if (await UseCordial(CordialType.Cordial))
                        {
                            return true;
                        }
                    }
                }

                if (CordialType == CordialType.Cordial && Me.MaxGP - Me.CurrentGP > 330)
                {
                    if (await UseCordial(CordialType.Cordial))
                    {
                        return true;
                    }
                }
            }

            return true;
        }

        private async Task<bool> UseCordial(CordialType cordialType, int maxTimeoutSeconds = 5)
        {
            if (CordialSpellData.Cooldown.TotalSeconds < maxTimeoutSeconds)
            {
                var cordial =
                    InventoryManager.FilledSlots.FirstOrDefault(
                        slot => slot.Item.Id == (uint)cordialType);

                if (cordial != null)
                {
                    Logging.Write(
                        "Using Cordial -> Waiting (sec): " + maxTimeoutSeconds + " CurrentGP: " + Me.CurrentGP);
                    if (await Coroutine.Wait(
                        TimeSpan.FromSeconds(maxTimeoutSeconds),
                        () =>
                        {
                            if (Me.IsMounted && CordialSpellData.Cooldown.TotalSeconds < 2)
                            {
                                Logging.Write("Dismounting to use cordial.");
                                Actionmanager.Dismount();
                                return false;
                            }

                            return cordial.CanUse(Me);
                        }))
                    {
                        cordial.UseItem(Me);
                        Logging.Write("Using " + cordialType);
                        return true;
                    }
                }
                else
                {
                    Logging.Write(Colors.Chartreuse, "No Cordial avilable, buy more " + cordialType);
                }
            }

            return false;
        }

        private async Task<bool> InteractWithNode()
        {
            var attempts = 0;
            while (attempts < 3 && !GatheringManager.WindowOpen && Behaviors.ShouldContinue)
            {
                while (MovementManager.IsFlying && Behaviors.ShouldContinue)
                {
                    Navigator.Stop();
                    Actionmanager.Dismount();
                    await Coroutine.Yield();
                }

                Poi.Current.Unit.Interact();

                if (await Coroutine.Wait(WindowDelay, () => GatheringManager.WindowOpen))
                {
                    continue;
                }

                if (FreeRange)
                {
                    Logging.Write("Gathering Window didn't open: Retrying. " + ++attempts);
                    continue;
                }

                Logging.Write("Gathering Window didn't open: Re-attempting to move into place. " + ++attempts);
                //SetFallbackGatherSpot(Node.Location, true);

                await MoveToGatherSpot();
            }

            if (!GatheringManager.WindowOpen)
            {
                if (!FreeRange)
                {
                    await MoveFromGatherSpot();
                }
                
                OnResetCachedDone();
                return false;
            }

            interactedWithNode = true;

            if (!await ResolveGatherItem())
            {
                ResetInternal();
                return false;
            }

            CheckForGatherRotationOverride();

            return true;
        }

        private async Task<bool> Gather()
        {
            if (!Blacklist.Contains(Poi.Current.Unit, BlacklistFlags.Interact))
            {
                var timeToBlacklist = GatherStrategy == GatherStrategy.TouchAndGo
                                          ? TimeSpan.FromSeconds(15)
                                          : TimeSpan.FromSeconds(
                                              Math.Max(gatherRotation.Attributes.RequiredTimeInSeconds + 6, 30));
                Blacklist.Add(Poi.Current.Unit, BlacklistFlags.Interact, timeToBlacklist, "Blacklisting node so that we don't retarget -> " + Poi.Current.Unit);
            }

            return await InteractWithNode()
                && await gatherRotation.Prepare(this)
                && await gatherRotation.ExecuteRotation(this)
                && await gatherRotation.Gather(this)
                && await Coroutine.Wait(6000, () => !Node.CanGather)
                && await WaitForGatherWindowToClose();
        }

        private async Task<bool> WaitForGatherWindowToClose()
        {
            while (GatheringManager.WindowOpen && Behaviors.ShouldContinue)
            {
                await Coroutine.Yield();
            }

            return true;
        }

        internal async Task<bool> Cast(uint id)
        {
            return await Actions.Cast(id, SpellDelay);
        }

        internal async Task<bool> Cast(Ability id)
        {
            return await Actions.Cast(id, SpellDelay);
        }

        internal async Task<bool> CastAura(uint spellId, int auraId = -1)
        {
            return await Actions.CastAura(spellId, SpellDelay, auraId);
        }

        internal async Task<bool> CastAura(Ability ability, AbilityAura auraId = AbilityAura.None)
        {
            return await Actions.CastAura(ability, SpellDelay, auraId);
        }

        internal async Task<bool> ResolveGatherItem()
        {
            if (!GatheringManager.WindowOpen)
            {
                return false;
            }

            var previousGatherItem = GatherItem;
            GatherItemIsFallback = false;
            GatherItem = null;
            CollectableItem = null;

            var windowItems = GatheringManager.GatheringWindowItems.ToArray();

            // TODO: move method to common so we use it on fish too
            if (InventoryItemCount() >= 100)
            {
                if (ItemNames != null && ItemNames.Count > 0)
                {
                    if (SetGatherItemByItemName(windowItems.OrderByDescending(i => i.SlotIndex)
                                           .Where(i => i.IsFilled && !i.IsUnknown && i.ItemId < 20).ToArray()))
                    {
                        return true;
                    }
                }

                GatherItem =
                    windowItems.Where(i => i.IsFilled && !i.IsUnknown)
                        .OrderByDescending(i => i.ItemId)
                        .FirstOrDefault(i => i.ItemId < 20);

                if (GatherItem != null)
                {
                    return true;
                }
            }

            if (DiscoverUnknowns)
            {
                var items =
                    new[] { 0U, 1U, 2U, 3U, 4U, 5U, 6U, 7U }.Select(GatheringManager.GetGatheringItemByIndex)
                        .ToArray();

                GatherItem = items.FirstOrDefault(i => i.IsUnknownChance() && i.Amount > 0);

                if (GatherItem != null)
                {
                    return true;
                }
            }

            if (Collectables != null && Collectables.Count > 0)
            {
                foreach (var collectable in Collectables)
                {
                    GatherItem =
                        windowItems.FirstOrDefault(
                            i =>
                            i.IsFilled && !i.IsUnknown
                            && string.Equals(
                                collectable.Name,
                                i.ItemData.EnglishName,
                                StringComparison.InvariantCultureIgnoreCase));

                    if (GatherItem != null)
                    {
                        CollectableItem = collectable;
                        return true;
                    }
                }
            }

            if (ItemNames != null && ItemNames.Count > 0)
            {
                if (SetGatherItemByItemName(windowItems))
                {
                    return true;
                }
            }

            if (Slot > -1 && Slot < 8)
            {
                GatherItem = GatheringManager.GetGatheringItemByIndex((uint)Slot);
            }

            if (GatherItem == null && (!AlwaysGather || GatherStrategy == GatherStrategy.TouchAndGo))
            {
                Poi.Clear("Skipping this node, no items we want to gather.");

                if (SkipWindowDelay > 0)
                {
                    await Coroutine.Sleep((int)SkipWindowDelay);
                }

                await CloseGatheringWindow();

                return false;
            }

            if (GatherItem != null)
            {
                return true;
            }

            GatherItemIsFallback = true;

            GatherItem =
                windowItems.Where(i => i.IsFilled && !i.IsUnknown)
                    .OrderByDescending(i => i.ItemId)
                    .FirstOrDefault(i => i.ItemId < 20) // Try to gather cluster/crystal/shard
                ?? windowItems.FirstOrDefault(i => i.IsFilled && !i.IsUnknown && !i.ItemData.Unique && !i.ItemData.Untradeable && i.ItemData.ItemCount() > 0) // Try to collect items you have that stack
                ?? windowItems.Where(i => i.Amount > 0 && !i.ItemData.Unique && !i.ItemData.Untradeable).OrderByDescending(i => i.SlotIndex).FirstOrDefault(); // Take last item that is not unique or untradeable

            // Seems we only have unknowns.
            if (GatherItem == null)
            {
                var items =
                    new[] { 0U, 1U, 2U, 3U, 4U, 5U, 6U, 7U }.Select(GatheringManager.GetGatheringItemByIndex)
                        .ToArray();

                GatherItem = items.FirstOrDefault(i => i.IsUnknownChance() && i.Amount > 0);

                if (GatherItem != null)
                {
                    return true;
                }

                Logging.Write(
                    Colors.PaleVioletRed,
                    "GatherCollectable: Unable to find an item to gather, moving on.");

                return false;
            }

            if (previousGatherItem == null || previousGatherItem.ItemId != GatherItem.ItemId)
            {
                Logging.Write(Colors.Chartreuse, "GatherCollectable: could not find item by slot or name, gathering " + GatherItem.ItemData + " instead.");
            }

            return true;
        }

        private void SetFallbackGatherSpot(Vector3 location, bool useMesh)
        {
            switch (DefaultGatherSpotType)
            {
                // TODO: Smart stealth implementation (where any enemy within x distance and i'm not behind them, use stealth approach and set stealth location as current)
                // If flying, land in area closest to node not in sight of an enemy and stealth.
                case GatherSpotType.StealthApproachGatherSpot:
                case GatherSpotType.StealthGatherSpot:
                    GatherSpot = new StealthGatherSpot { NodeLocation = location, UseMesh = useMesh };
                    break;
                // ReSharper disable once RedundantCaseLabel
                case GatherSpotType.GatherSpot:
                default:
                    GatherSpot = new GatherSpot { NodeLocation = location, UseMesh = useMesh };
                    break;
            }
        }

        private bool SetGatherItemByItemName(ICollection<GatheringItem> windowItems)
        {
            foreach (var itemName in ItemNames)
            {
                GatherItem =
                    windowItems.FirstOrDefault(
                        i =>
                        i.IsFilled && !i.IsUnknown
                        && string.Equals(
                            itemName,
                            i.ItemData.EnglishName,
                            StringComparison.InvariantCultureIgnoreCase));

                if (GatherItem != null && (!GatherItem.ItemData.Unique || GatherItem.ItemData.ItemCount() == 0))
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckForGatherRotationOverride()
        {
            if (!gatherRotation.CanBeOverriden || DisableRotationOverride)
            {
                if (!GatherItem.IsUnknown)
                {
                    return;
                }

                Logging.Write(Colors.Chartreuse, "GatherCollectable: Item to gather is unknown, we are overriding the rotation to ensure we can collect it.");
            }

            var rotationAndTypes = Rotations
                .Select(
                    r => new
                             {
                                 Rotation = r.Value,
                                 OverrideValue = r.Value.ResolveOverridePriority(this)
                             })
                .Where(r => r.OverrideValue > -1)
                .OrderByDescending(r => r.OverrideValue).ToArray();

            var rotation = rotationAndTypes.FirstOrDefault();

            if (rotation == null || object.ReferenceEquals(rotation.Rotation, gatherRotation))
            {
                return;
            }

            Logging.Write(
                Colors.Chartreuse,
                "GatherCollectable: Rotation Override -> Old: "
                + gatherRotation.Attributes.Name
                + " , New: "
                + rotation.Rotation.Attributes.Name);

            gatherRotation = rotation.Rotation;
        }

        private bool FreeRangeConditional()
        {
            if (freeRangeConditionFunc == null)
            {
                freeRangeConditionFunc = ScriptManager.GetCondition(FreeRangeCondition);
            }

            return freeRangeConditionFunc();
        }

        private int InventoryItemCount()
        {
            return InventoryManager.FilledSlots.Count(c => c.BagId != InventoryBagId.KeyItems);
        }

        internal async Task CloseGatheringWindow()
        {
            var window = RaptureAtkUnitManager.GetWindowByName("Gathering");

            while (window != null && window.IsValid && Behaviors.ShouldContinue)
            {
                window.SendAction(1, 3, 0xFFFFFFFF);
                await Coroutine.Yield();
            }
        }

        internal bool IsEphemeral()
        {
            return Node.EnglishName.IndexOf("ephemeral", StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        internal bool IsUnspoiled()
        {
            // Temporary until we decide if legendary have any diff properties or if we should treat them the same.
            return Node.EnglishName.IndexOf("unspoiled", StringComparison.InvariantCultureIgnoreCase) >= 0
                   || Node.EnglishName.IndexOf("legendary", StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}