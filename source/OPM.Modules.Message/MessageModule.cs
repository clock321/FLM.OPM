using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using OPM.Core;
using OPM.Modules.Message.Views;

namespace OPM.Modules.Message
{
  public class MessageModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      containerProvider
        .Resolve<IRegionManager>()
        .RegisterViewWithRegion(RegionNames.RightRegion, typeof(MessageView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}