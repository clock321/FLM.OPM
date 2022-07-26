using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace OPM.Views
{
  public partial class MainWindow : FluentWindow
  {
    public MainWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}

