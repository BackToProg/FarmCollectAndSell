using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    [RequireComponent(typeof(HayrickBuyer))]
    public class TradeZone : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform _activeSellPoint;

        private HayrickBuyer _hayrickBuyer;
        
        public Transform ActiveSellPoint => _activeSellPoint;
        public HayrickBuyer HayrickBuyer => _hayrickBuyer;

        private void Awake()
        {
            _hayrickBuyer = GetComponent<HayrickBuyer>();
        }
    }
}
