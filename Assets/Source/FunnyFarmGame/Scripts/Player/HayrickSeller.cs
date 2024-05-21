using System.Collections.Generic;
using Source.FunnyFarmGame.Scripts.HaybaleActions;
using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    [RequireComponent(typeof(HayrickCollector))]
    public class HayrickSeller : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _trigger;

        private readonly Stack<Hayrick> _haybaleMoveToStock = new Stack<Hayrick>();
        private WaitForSeconds _waitForSeconds;
        private HayrickCollector _hayrickCollector;
        private float _money;

        public float Money => _money;

        private void OnEnable() =>
            _trigger.TriggerEnter += TriggerEnter;

        private void Awake()
        {
            _hayrickCollector = GetComponent<HayrickCollector>();
        }

        public void AddHaybale(Hayrick hayrick)
        {
            _haybaleMoveToStock.Push(hayrick);
        }

        private void TriggerEnter(IInteractable interactable)
        {
            if (interactable is not TradeZone sellZone) 
                return;
            
            Trade(sellZone);
        }

        private void Trade(TradeZone tradeZone)
        {
            Transform sellPoint = tradeZone.GetComponent<TradeZone>().ActiveSellPoint;
            HayrickBuyer hayrickBuyer = tradeZone.HayrickBuyer;

            while (_haybaleMoveToStock.Count > 0)
            {
                Hayrick hayrick = _haybaleMoveToStock.Pop();
                hayrick.HayrickMovement.MoveToTarget(sellPoint);
                hayrickBuyer.Buy(hayrick);
            }

            _hayrickCollector.ResetCollectTransform();
        }
        
        private void OnDisable() =>
            _trigger.TriggerEnter -= TriggerEnter;
    }
}