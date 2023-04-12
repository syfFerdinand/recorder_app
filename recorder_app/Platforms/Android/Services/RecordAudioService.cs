using Android.Media;
using recorder_app.Interface;

namespace recorder_app.Service
{
    public class RecordAudioService : IRecordAudioService
    {
        #region Fields
        private MediaRecorder mediaRecorder;
        private string storagePath;
        private bool isRecordStarted = false;
        #endregion
            
        #region Methods
        void IRecordAudioService.StartRecord()
        {
            if (mediaRecorder == null)
            {
                SetAudioFilePath();
                mediaRecorder = new MediaRecorder();
                mediaRecorder.Reset();
                mediaRecorder.SetAudioSource(AudioSource.Mic);
                mediaRecorder.SetOutputFormat(OutputFormat.AacAdts);
                mediaRecorder.SetAudioEncoder(AudioEncoder.Aac);
                mediaRecorder.SetOutputFile(storagePath);
                mediaRecorder.Prepare();
                mediaRecorder.Start();
            }
            else
            {
                mediaRecorder.Resume();
            }
            isRecordStarted = true;
        }

        string IRecordAudioService.StopRecord()
        {
            if (mediaRecorder == null)
            {
                return string.Empty;
            }
            mediaRecorder.Resume();
            mediaRecorder.Stop();
            mediaRecorder = null;
            isRecordStarted = false;
            return storagePath;
        }
        void IRecordAudioService.PauseRecord()
        {
            if (mediaRecorder == null)
            {
                return;
            }
            mediaRecorder.Pause();
            isRecordStarted = false;
        }

        void IRecordAudioService.ResetRecord()
        {
            if (mediaRecorder != null)
            {
                mediaRecorder.Resume();
                mediaRecorder.Reset();
            }
            mediaRecorder = null;
            isRecordStarted = false;
        }

        internal void SetAudioFilePath()
        {
            string fileName = "/Record_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".mp3";
            var path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            storagePath = path + fileName;
            Directory.CreateDirectory(storagePath);
        }
        #endregion
    }
}
