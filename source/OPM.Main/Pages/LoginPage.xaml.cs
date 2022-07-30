using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OPM.Core;
using OPM.PageModels;
using ReactiveUI;

namespace OPM.Pages
{
  public class LoginPage : BaseControl<LoginViewModel>
  {
    public LoginPage()
    {
      this.InitializeComponent();
    }
    public Button testBtn => this.FindControl<Button>("testBtn");
    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
      this.WhenActivated(disposables =>
      {
        ViewModel.loginPage = this;
          // Bind the 'ExampleCommand' to 'ExampleButton' defined above.
        //this.BindCommand(ViewModel, x => x.ExampleCommand, x => x.testBtn)
            //.DisposeWith(disposables);
      });

    }
  }
}
