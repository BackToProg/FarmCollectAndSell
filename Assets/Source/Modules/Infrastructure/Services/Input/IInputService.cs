using UnityEngine;

namespace Source.Modules.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get;  }
    }
}