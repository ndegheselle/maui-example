using CommunityToolkit.Maui;
using maui_example.ViewModels;
using maui_example.Views;
using Microsoft.Extensions.Logging;

namespace maui_example;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterViewModels()
            .RegisterViews()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        return builder.Build();
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
        mauiAppBuilder.Services.AddSingleton<ParametersViewModel>();

        return mauiAppBuilder;
    }

    // Personnaly think it strange to register views as a service, but it's the way to handle Dependency Injection in MAUI
    // Instead it's also possible to use ServiceHelper.GetService in a parameterless constructor
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<MainPage>();
        mauiAppBuilder.Services.AddTransient<ParametersViewModel>();
        mauiAppBuilder.Services.AddTransient<ParametersPage>();
        return mauiAppBuilder;
    }
}