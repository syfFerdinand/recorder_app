using recorder_app.Interface;
using recorder_app.Service;
using Syncfusion.Maui.ListView.Hosting;

namespace recorder_app;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("AudioIconFonts.ttf", "AudioIconFonts");
            });

#if ANDROID || IOS
        builder.Services.AddTransient<IAudioPlayerService, AudioPlayerService>();
        builder.Services.AddTransient<IRecordAudioService, RecordAudioService>();
#endif
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AppShell>();
        builder.ConfigureSyncfusionListView();
        return builder.Build();
	}
}
