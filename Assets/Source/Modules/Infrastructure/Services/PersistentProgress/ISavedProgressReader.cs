using Source.Modules.Data;

namespace Source.Modules.Infrastructure.Services.PersistentProgress
{
  public interface ISavedProgressReader
  {
    void LoadProgress(PlayerProgress progress);
  }
}