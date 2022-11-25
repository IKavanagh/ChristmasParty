using Christmas.Services;
using Christmas.View;
using Christmas.ViewModel;
using CommunityToolkit.Maui;

namespace Christmas;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("FontAwesome-Regular", "FontAwesomeRegular");
                fonts.AddFont("FontAwesome-Solid", "FontAwesomeSolid");
                fonts.AddFont("FontAwesomeBrands-Regular", "FontAwesomeBrandsRegular");
            });

        // Services
        builder.Services.AddSingleton<AuthenticationService>();
        builder.Services.AddSingleton<EventService>();
        builder.Services.AddSingleton<QuestionService>();

        // ViewModels
        builder.Services.AddSingleton<AboutViewModel>();
        builder.Services.AddSingleton<EventsViewModel>();
        builder.Services.AddSingleton<QuestionsViewModel>();

        // Pages
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddSingleton<EventsPage>();
        builder.Services.AddSingleton<LandingPage>();
        builder.Services.AddSingleton<QuestionsPage>();

        return builder.Build();
    }
}
