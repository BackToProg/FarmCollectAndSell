using Source.FunnyFarmGame.Scripts.InteractObjects;
using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.HaybaleActions
{
    [RequireComponent(typeof(HayrickMovement))]
    public class Hayrick : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _haybalePrice;

        private HayrickMovement _hayrickMovement;

        public float HaybalePrice => _haybalePrice;
        public HayrickMovement HayrickMovement => _hayrickMovement;

        private void Awake()
        {
            _hayrickMovement = GetComponent<HayrickMovement>();
        }
    }
}