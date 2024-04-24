using System.Collections.Generic;
using Source.Modules.Infrastructure.Services;
using Source.Modules.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Source.Modules.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
        void CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}