using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.Common;
using OPM.PageModels;

namespace OPM.Pages
{
  public class LoginPage : BaseControl<LoginViewModel>
  {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
