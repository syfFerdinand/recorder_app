using recorder_app.Interface;
using recorder_app.ViewModels;

namespace recorder_app;

public partial class MainPage : ContentPage
{

    public MainPage(IAudioPlayerService audioPlayerService, IRecordAudioService recordAudioService)
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel(audioPlayerService, recordAudioService);
    } 
}

