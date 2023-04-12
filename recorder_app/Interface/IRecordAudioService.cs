
namespace recorder_app.Interface
{
    public interface IRecordAudioService
    {
    void StartRecord();
    string StopRecord();
    void PauseRecord();
    void ResetRecord();
}
}
