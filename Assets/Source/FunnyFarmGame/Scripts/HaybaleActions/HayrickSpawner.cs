using Source.Modules.Infrastructure.Factory;
using Source.Modules.Infrastructure.Services;
using UnityEngine;


namespace Source.FunnyFarmGame.Scripts.Haybale
{
    public class HayrickSpawner : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private int _cutCornCounter;
        
        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }
        
        private void Update()
        {
            if (_cutCornCounter >= 80)
            {
                GameObject haybale = _gameFactory.CreateHaybale(gameObject);
                _cutCornCounter = 0;
            }
        }
        
        public void ChangeCornCounter()
        {
            _cutCornCounter++;
        }
    }
}
