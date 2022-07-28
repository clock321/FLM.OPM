using Avalonia;
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
      .UseReactiveUI()
      .LogToTrace();

    public static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
      Splat.Locator.CurrentMutable.UseSerilogFullLogger();
      BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }


  }
}
