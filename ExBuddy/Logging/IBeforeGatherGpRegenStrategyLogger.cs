namespace ExBuddy.Logging
{
    using OrderBotTags.Gather.Strategies;

    internal interface IBeforeGatherGpRegenStrategyLogger : ICordialConsumerLogger, IGpRegeneratorLogger, IStatusLogger, IGathererLogger
    {
        void LogReport(IGpRegenStrategy strategy);
    }
}
