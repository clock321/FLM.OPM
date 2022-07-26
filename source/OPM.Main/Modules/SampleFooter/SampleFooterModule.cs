using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using OPM.Common;
using OPM.Modules.SampleFooter.ViewModels;
using OPM.Modules.SampleFooter.Views;

namespace OPM.Modules.SampleFooter
{
  public class SampleFooterModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.FooterRegion, typeof(SampleFooterView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // containerRegistry.Register<IMailService, MailService>();
      containerRegistry.RegisterInstance(typeof(SampleFooterViewModel));
    }
  }
}
