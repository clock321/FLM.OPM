using Avalonia;
using Avalonia.Extensions.Controls;
using Avalonia.Extensions.Media;
using Avalonia.ReactiveUI;
using Serilog;
using Splat.Serilog;

namespace OPM
{
  internal class Program
  {

    public static AppBuilder BuildAvaloniaApp() => AppBuilder
      .Configure<App>()
      .UsePlatformDetect()
      .With(new X11PlatformOptions {
        EnableMultiTouch = false,
        UseDBusMenu = true
      })
      .With(new Win32PlatformOptions {
        EnableMultitouch = true,
        AllowEglInitialization = true
      })
      .UseSkia()
      .UseDoveExtensions()
      //.UseVideoView()
      //.UseAudioControl()
      .UseChineseInputSupport()
      .UseReactiveUI()
      .LogToTrace();

    public static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration()
        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
      Splat.Locator.CurrentMutable.UseSerilogFullLogger();
      BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }


  }
}
