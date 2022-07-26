using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.ViewModels;

namespace OPM.Pages
{
    public class OverviewPage : UserControl
    {
        public OverviewPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
