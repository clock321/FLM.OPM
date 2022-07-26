using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.Common;
using OPM.ViewModels;

namespace OPM.Views
{
  public partial class SettingsView : BaseControl<SettingsViewModel>
  {
    public SettingsView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
