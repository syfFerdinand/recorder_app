using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace recorder_app.Model
{
    public class Audio : INotifyPropertyChanged
    {
        #region Private fields
        private bool isPlayVisible;
        private bool isPauseVisible;
        private string currentAudioPosition;
        #endregion

        public Audio()
        {
            isPlayVisible = true;     
        }

        #region Properties
        public string Audioname { get; set; }
        public string AudioURL { get; set; }
        public string Caption { get; set; }
        public bool IsPlayVisible
        {
            get { return isPlayVisible; }
            set
            {
                isPlayVisible = value;
                OnPropertyChanged();
                isPauseVisible = !value;
            }
        }

        public bool IsPauseVisible
        {
            get { return isPauseVisible; }
            set { isPauseVisible = value; OnPropertyChanged(); }
        }

        public string CurrentAudioPosition
        {
            get { return currentAudioPosition; }
            set
            {
                if (string.IsNullOrEmpty(currentAudioPosition))
                {
                    currentAudioPosition = string.Format("{0:mm\\:ss}", new TimeSpan());
                }
                else
                {
                    currentAudioPosition = value;
                }
                OnPropertyChanged();
            }
        }
        #endregion

        #region Interface

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
