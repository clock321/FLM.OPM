using System.Collections.ObjectModel;
using OPM.Core;
using OPM.Models;
using MediatR;
using Prism.Commands;
using PropertyChanged;
using ReactiveUI.Fody.Helpers;

namespace OPM.PageModels
{
  [AddINotifyPropertyChangedInterface]
  public class LoginViewModel : ViewModelBase
  {
    public DelegateCommand CommandShowDashboard => new DelegateCommand(() =>
    {

      System.Diagnostics.Debug.Print($"{username}_{password}");

    });

    public DelegateCommand CommandGetNewToken => new DelegateCommand(GetNewToken);

    public DelegateCommand CommandApplyNewToken => new DelegateCommand(ApplyNewToken);

    public LoginViewModel(IMediator mediator) : base(mediator)
    {
    }

    [Reactive]
    public string username { get; set; }

    [Reactive]
    public string password { get; set; }

    [Reactive]
    public string NewToken { get; set; }

    void GetNewToken()
    {

    }

    void ApplyNewToken()
    {

    }
  }
}
