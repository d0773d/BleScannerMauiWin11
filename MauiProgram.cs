using BleScannerMaui.Pages;
using BleScannerMaui;
using BleScannerMaui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

#if WINDOWS
using Windows.Devices.Bluetooth;
#endif


namespace BleProvisioner;

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
            });

        // Dependency injection
        builder.Services.AddSingleton<IBluetoothService, BluetoothService>()
        .AddSingleton<ILogService, LogService>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<WifiProvisioningPage>();

        return builder.Build();
    }
}