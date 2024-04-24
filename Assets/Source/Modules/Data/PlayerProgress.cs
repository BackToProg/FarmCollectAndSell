using System;

namespace Source.Modules.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
        }
    }

    [Serializable]
    public class LevelState
    {
        public WorldData WorldData;

        public LevelState(WorldData worldData)
        {
            WorldData = worldData;
        }
    }
}