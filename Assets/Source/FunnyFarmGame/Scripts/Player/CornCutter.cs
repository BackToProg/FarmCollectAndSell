using Source.FunnyFarmGame.Scripts.Haybale;
using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    public class CornCutter : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _trigger;
        [SerializeField] private HaybaleSpawner _haybaleSpawner;

        private void OnEnable() => 
            _trigger.TriggerEnter += TriggerEnter;

        private void TriggerEnter(Collider obj)
        {
            obj.gameObject.SetActive(false);
            _haybaleSpawner.ChangeCornCounter();
        }

        private void OnDisable() => 
            _trigger.TriggerEnter -= TriggerEnter;
    }
}