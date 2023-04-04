using Android.Media;
using recorder_app.src.Interface;

namespace recorder_app.src.Service
{
    public class AndroidRecordAudio : IRecordAudio
    {
        #region Fields
        private MediaRecorder mediaRecorder;
        private string storagePath;
        private bool isRecordStarted = false;
        #endregion

        #region Methods
        void IRecordAudio.StartRecord()
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

        string IRecordAudio.StopRecord()
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
        void IRecordAudio.PauseRecord()
        {
            if (mediaRecorder == null)
            {
                return;
            }
            mediaRecorder.Pause();
            isRecordStarted = false;
        }

        void IRecordAudio.ResetRecord()
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
