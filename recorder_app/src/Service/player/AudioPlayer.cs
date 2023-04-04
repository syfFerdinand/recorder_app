using Android.Media;
using recorder_app.src.Interface;

namespace recorder_app.src.Service
{
    
    public class AudioPlayer : IAudioPlayer
    {
        #region Fields
        private MediaPlayer _mediaPlayer;
        private int currentPosistionLength = 0;
        private bool isPrepared;
        private bool isCompleted;
        #endregion
        void IAudioPlayer.PlayAudio(string filePath)
        {
            if (_mediaPlayer != null && _mediaPlayer.IsPlaying)
            {
                _mediaPlayer.SeekTo(currentPosistionLength);
                currentPosistionLength = 0;
                _mediaPlayer.Start();
            }else if(_mediaPlayer == null && !_mediaPlayer.IsPlaying)
            {
                try
                {
                    isCompleted = false;
                    _mediaPlayer = new MediaPlayer();
                    _mediaPlayer.SetDataSource(filePath);
                    _mediaPlayer.SetAudioStreamType(Android.Media.Stream.Music);
                    _mediaPlayer.PrepareAsync();
                    _mediaPlayer.Prepared += (sender, args) =>
                    {
                        isPrepared = true;
                        _mediaPlayer.Start();
                    };
                    _mediaPlayer.Completion += (sender, args) =>
                    {
                        isCompleted = true;
                    };
                }
                catch (Exception e)
                {
                    _mediaPlayer = null;
                }
            }
        }

        void IAudioPlayer.Pause()
        {
            if(_mediaPlayer != null && _mediaPlayer.IsPlaying)
            {
                _mediaPlayer.Pause();
                currentPosistionLength = _mediaPlayer.CurrentPosition;
            }
        }

        void IAudioPlayer.Stop()
        {
            if(_mediaPlayer != null)
            {
                if(isPrepared)
                {
                    _mediaPlayer.Stop();
                    _mediaPlayer.Release();
                    isPrepared = false;
                }
                isCompleted = false;
                _mediaPlayer = null;
            }
        }

        string IAudioPlayer.GetCurrentPlayTime()
        {
            if(_mediaPlayer != null)
            {
                var positionTimeSeconds = double.Parse(_mediaPlayer.CurrentPosition.ToString());
                positionTimeSeconds = positionTimeSeconds /1000;
                TimeSpan currentTime = TimeSpan.FromSeconds(positionTimeSeconds);
                string currentPlayTime = string.Format("{0:mm\\:}", new TimeSpan());
                return currentPlayTime;
            }
            return null;
        }

        bool IAudioPlayer.CheckFinishedPlayingAudio()
        {
            return isCompleted;
        }
    }
}