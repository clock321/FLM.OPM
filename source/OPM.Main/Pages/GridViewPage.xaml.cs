using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.ViewModels;


namespace OPM.Pages
{
    public class GridViewPage : UserControl
    {
        public GridViewPage()
        {
            this.InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
