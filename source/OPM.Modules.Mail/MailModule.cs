using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using OPM.Core;
using OPM.Modules.Mail.Services;
using OPM.Modules.Mail.ViewModels;
using OPM.Modules.Mail.Views;

namespace OPM.Modules.Mail
{
  public class MailModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(MailView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<IMailService, MailService>();
      containerRegistry.RegisterInstance(typeof(MailViewModel));
    }
  }
}