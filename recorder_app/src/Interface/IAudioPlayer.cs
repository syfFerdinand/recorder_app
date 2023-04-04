
namespace recorder_app.src.Interface
{
    public interface IAudioPlayer
    {
    void PlayAudio(string filePath);
    void Pause();
    void Stop();
    string GetCurrentPlayTime();
    bool CheckFinishedPlayingAudio();
    }
}
