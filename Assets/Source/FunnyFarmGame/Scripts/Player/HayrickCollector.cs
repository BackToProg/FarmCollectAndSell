using Source.FunnyFarmGame.Scripts.HaybaleActions;
using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    [RequireComponent(typeof(HayrickSeller))]
    public class HayrickCollector : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _trigger;
        [SerializeField] protected Transform _hayrickCollectPointLeft;
        [SerializeField] protected Transform _hayrickCollectPointRight;
        
        private readonly float _positionDelta = 1.25f; //TODO Отправить в константы
        private int _haybaleCount;
        private HayrickSeller _hayrickSeller;
        private Transform _haybalePositionTransform;
        private float _initialPositionY;

        private void OnEnable() => 
            _trigger.TriggerEnter += TriggerEnter;

        private void Awake()
        {
            _hayrickSeller = GetComponent<HayrickSeller>();
            _initialPositionY = _hayrickCollectPointLeft.position.y;
        }

        private void TriggerEnter(IInteractable interactable)
        {
            if (interactable is not Hayrick hayrick) 
                return;
            
            DefinePlaceToCollect();
            hayrick.HayrickMovement.PickUp(transform, _haybalePositionTransform);
            _hayrickSeller.AddHaybale(hayrick);
            _haybaleCount++;
        }

        private void OnDisable() => 
            _trigger.TriggerEnter -= TriggerEnter;

        public void ResetCollectTransform()
        {
            _hayrickCollectPointLeft.position = new Vector3(_hayrickCollectPointLeft.position.x, _initialPositionY, _hayrickCollectPointLeft.position.z);
            _hayrickCollectPointRight.position = new Vector3(_hayrickCollectPointRight.position.x, _initialPositionY, _hayrickCollectPointRight.position.z);
        }

        private void DefinePlaceToCollect()
        {
            Vector3 position;

            if (_haybaleCount % 2 == 0)
            {
                _haybalePositionTransform = _hayrickCollectPointLeft;
                position = _haybalePositionTransform.position;
                position.y += _positionDelta;
                _haybalePositionTransform.position = position;
            }
            else
            {
                _haybalePositionTransform = _hayrickCollectPointRight;
                position = _haybalePositionTransform.position;
                position.y += _positionDelta;
                _haybalePositionTransform.position = position;
            }
        }
    }
}
