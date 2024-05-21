using Source.FunnyFarmGame.Scripts.HaybaleActions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    public class HayrickBuyer : MonoBehaviour
    {
        public float Buy(Hayrick hayrick)
        {
            return hayrick.HaybalePrice;
        }
    }
}
