using Source.Modules.Data;
using Source.Modules.Infrastructure.Services.PersistentProgress;
using Source.Modules.Infrastructure.Services.SaveLoad;

namespace Source.Modules.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _stateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() => 
            _progressService.Progress = 
                _saveLoadService.LoadProgress() 
                ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress("Main");
        }
    }
}