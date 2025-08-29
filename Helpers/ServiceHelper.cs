using System;

namespace BleProvisioner;

public static class ServiceHelper
{
    public static TService GetService<TService>() =>
        Current.GetService<TService>();

    public static IServiceProvider Current =>
        Application.Current?.Handler?.MauiContext?.Services;
}
