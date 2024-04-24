using Source.Modules.Infrastructure.Services;
using UnityEngine;

namespace Source.Modules.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}