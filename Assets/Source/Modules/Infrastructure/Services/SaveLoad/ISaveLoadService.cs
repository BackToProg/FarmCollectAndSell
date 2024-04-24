using Source.Modules.Data;

namespace Source.Modules.Infrastructure.Services.SaveLoad
{
  public interface ISaveLoadService : IService
  {
    void SaveProgress();
    PlayerProgress LoadProgress();
  }
}