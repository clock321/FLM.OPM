using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OPM.Modules.SampleFooter.Views
{
  public partial class SampleFooterView : UserControl
  {
    public SampleFooterView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
