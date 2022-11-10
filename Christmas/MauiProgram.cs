﻿using Christmas.Services;
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
        builder.Services.AddSingleton<EventService>();

        // ViewModels
        builder.Services.AddSingleton<EventsViewModel>();

        // Pages
        builder.Services.AddSingleton<EventsPage>();

        return builder.Build();
    }
}
