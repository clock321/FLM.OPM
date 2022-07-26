using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.Core;
using OPM.ViewModels;

namespace OPM.Views
{
    public class MainTabView : BaseControl<MainTabViewModel>
  {
        public MainTabView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);            
        }
    }
}
