using Prism.Regions;
using OPM.Core;
using MediatR;
namespace OPM.ViewModels
{
  public class DashboardViewModel : ViewModelBase
  {
    private IRegionManager _regionManager;

    public DashboardViewModel(IMediator mediator, IRegionManager regionManager) : base(mediator)
    {
      _regionManager = regionManager;

      Title = "Dashboard - No New Messages";
    }
  }
}
