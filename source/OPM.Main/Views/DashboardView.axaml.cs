using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.Core;
using OPM.ViewModels;


namespace OPM.Views
{
  public partial class DashboardView : BaseControl<DashboardViewModel>
  {
    public DashboardView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
