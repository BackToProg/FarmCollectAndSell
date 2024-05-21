using Source.FunnyFarmGame.Scripts.Haybale;
using Source.FunnyFarmGame.Scripts.InteractObjects;
using Source.Modules.Infrastructure.Actions;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    public class CornCutter : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _trigger;
        [SerializeField] private HayrickSpawner _hayrickSpawner;

        private void OnEnable() => 
            _trigger.TriggerEnter += TriggerEnter;

        private void TriggerEnter(IInteractable interactable)
        {
            if (interactable is not Corn corn) return;

            corn.Deactivate();
            _hayrickSpawner.ChangeCornCounter();
        }

        private void OnDisable() => 
            _trigger.TriggerEnter -= TriggerEnter;
    }
}