using System.Collections.ObjectModel;
using OPM.Common;
using OPM.Main.Models;
using MediatR;
using Prism.Commands;


namespace OPM.ViewModels
{
  public class MainTabViewModel : ViewModelBase
  {
    public DelegateCommand CommandShowDashboard => new DelegateCommand(() => {

      System.Diagnostics.Debug.Print("CommandShowDashboard");

    });

    public MainTabViewModel(IMediator mediator) : base(mediator)
    {
    }

    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();
  }
}
