using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.Primitives;
using OPM.Core;
using OPM.ViewModels;

namespace OPM.Views
{
  public class NavigationView : BaseControl<MainWindowViewModel>
  {
    public NavigationView()
    {
      InitializeComponent();
    }

    private void TabStrip_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {

      System.Diagnostics.Debug.Print(e.ToString());

      var vm = this.ViewModel;

      if (vm != null)
        vm.SelectedTabIndex = 1;

    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
