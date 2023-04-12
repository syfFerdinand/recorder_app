
namespace recorder_app.Interface
{
    public interface IAudioPlayerService
    {
    void PlayAudio(string filePath);
    void Pause();
    void Stop();
    string GetCurrentPlayTime();
    bool CheckFinishedPlayingAudio();
    }
}
