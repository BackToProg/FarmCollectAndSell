using Source.Modules.Infrastructure.Services;
using Source.Modules.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Source.Modules.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;
        
        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _saveLoadService.SaveProgress();
                Debug.Log("Progress Saved");
            }
        }
    }
}