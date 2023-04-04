
namespace recorder_app.src.Interface
{
    public interface IRecordAudio
{
    void StartRecord();
    string StopRecord();
    void PauseRecord();
    void ResetRecord();
}
}
