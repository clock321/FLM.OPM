using Prism.Regions;
using OPM.Common;
using MediatR;

namespace OPM.ViewModels
{
  public class SettingsViewModel : ViewModelBase
  {
    private IRegionManager _regionManager;

    public SettingsViewModel(IMediator mediator, IRegionManager regionManager) : base(mediator)
    {
      _regionManager = regionManager;

      Title = "Settings";
    }
  }
}
