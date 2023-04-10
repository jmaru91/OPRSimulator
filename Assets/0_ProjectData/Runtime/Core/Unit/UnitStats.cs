namespace OPR
{
    public struct UnitStats
    {
        public string Name { get; }

        public ModelStats ModelStats { get; }

        public int ModelsCount { get; }

        public UnitStats(string name, ModelStats modelStats, int modelsCount)
        {
            Name = name;
            ModelStats = modelStats;
            ModelsCount = modelsCount;
        }
    }
}