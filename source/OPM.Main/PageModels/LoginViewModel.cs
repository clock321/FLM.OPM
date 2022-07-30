using System.Collections.ObjectModel;
using OPM.Core;
using OPM.Models;
using MediatR;
using Prism.Commands;
using PropertyChanged;
using ReactiveUI.Fody.Helpers;
using OPM.Core.Http;
using Avalonia;
using ReactiveUI;
using Avalonia.Controls;
using Avalonia.Extensions.Controls;

namespace OPM.PageModels
{
  [AddINotifyPropertyChangedInterface]
  public class LoginViewModel : ViewModelBase
  {
    public DelegateCommand CommandShowDashboard => new DelegateCommand(() =>
    {
      //var AccessTokenSingleton = CommonServiceLocator.ServiceLocator.Current.GetInstance<AccessTokenSingleton>();
      //AccessTokenSingleton.access_token = "test";
      System.Diagnostics.Debug.Print($"{username}_{password}");
      //var AssetLoader = AvaloniaLocator.Current.GetService<Avalonia.Platform.IAssetLoader>();
      Serilog.Log.Information($"Log:{username}_{password}");

      //var btn= loginPage.FindControl<Button>("testBtn");
      //btn.Content += "1";

      //Avalonia.Extensions.Controls.MessageBox.Show(Views.MainWindow.Instance, "tips", "ScrollView -> Scroll End");
      //PopupToast.Show("大大大大大大大大大大大大大大大大大大");
      Views.MainWindow.ShowToast("大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大");
      //NotifyWindow window = new NotifyWindow();
      //window.Content = new TextBlock { Text = "大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大大" };
      //var options = new NotifyOptions(ShowPosition.BottomRight, new Size(160, 60), ScollOrientation.Vertical);
      //window.Show(options);
    });

    public Pages.LoginPage loginPage;

    public DelegateCommand CommandGetNewToken => new DelegateCommand(GetNewToken);

    public DelegateCommand CommandApplyNewToken => new DelegateCommand(ApplyNewToken);

    AbpHttpClientBase HttpClient;
    //Unity.IUnityContainer unityContainer;

    public LoginViewModel(IMediator mediator, AbpHttpClientBase abpHttpClient) : base(mediator)
    {
      HttpClient = abpHttpClient;

    }

    [Reactive]
    public string username { get; set; }

    [Reactive]
    public string password { get; set; }

    [Reactive]
    public string NewToken { get; set; }

    void GetNewToken()
    {
      //ContainerExtensions
     
    }

    void ApplyNewToken()
    {
 
      //unityContainer.Resolve<>
    }
  }
}
