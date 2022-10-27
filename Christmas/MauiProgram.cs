using Christmas.Services;
using Christmas.View;
using Christmas.ViewModel;
using Sharpnado.Tabs;

namespace Christmas;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSharpnadoTabs(loggerEnable: false)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<EventService>();

        // ViewModels
        builder.Services.AddSingleton<EventsViewModel>();

        // Pages
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
