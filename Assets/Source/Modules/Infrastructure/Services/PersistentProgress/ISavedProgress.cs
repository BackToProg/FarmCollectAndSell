using Source.Modules.Data;

namespace Source.Modules.Infrastructure.Services.PersistentProgress
{
  public interface ISavedProgress : ISavedProgressReader
  {
    void UpdateProgress(PlayerProgress progress);
  }
}