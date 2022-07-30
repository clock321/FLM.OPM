using Avalonia;
using Avalonia.Controls;
using Avalonia.Extensions.Controls;
using Avalonia.Markup.Xaml;



namespace OPM.Views
{
  public partial class MainWindow : FluentWindow
  {
    public MainWindow()
    {
      _Instance = this;
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
      //MessageBox.Show("test", "etest");
    }

    public static void ShowToast(string val)
    {
      PopupToast.Show(val, _Instance);
      //PopupToast.Show(val, _Instance.Position.X+240, _Instance.Position.Y, _Instance.ActualWidth()-240, _Instance.ActualHeight()); 
    }

    public static void MessageBoxShow(string title, string message, MessageBoxButtons messageBoxButtons = MessageBoxButtons.OkNo)
    {
      MessageBox.Show(_Instance, title, message, messageBoxButtons);
    }

    private static MainWindow _Instance;
    public static MainWindow Instance => _Instance;

  }
}

