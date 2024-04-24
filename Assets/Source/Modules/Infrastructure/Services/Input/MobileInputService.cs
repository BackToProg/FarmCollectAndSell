using UnityEngine;

namespace Source.Modules.Infrastructure.Services.Input
{
    class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}