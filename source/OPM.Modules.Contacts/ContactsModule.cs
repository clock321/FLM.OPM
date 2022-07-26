using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using OPM.Core;
using OPM.Modules.Contacts.Views;

namespace OPM.Modules.Contacts
{
  public class ContactsModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.RightRegion, typeof(ContactsView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}