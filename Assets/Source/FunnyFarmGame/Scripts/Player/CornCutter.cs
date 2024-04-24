using UnityEngine;

namespace Source.FunnyFarmGame.Scripts.Player
{
    public class CornCutter : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _trigger;

        private void OnEnable() => 
            _trigger.TriggerEnter += TriggerEnter;

        private void TriggerEnter(Collider obj) => 
            obj.gameObject.SetActive(false);

        private void OnDisable() => 
            _trigger.TriggerEnter -= TriggerEnter;
    }
}