using OPM.Core;
using MediatR;

namespace OPM.Modules.Contacts.ViewModels
{
  public class ContactsViewModel : ViewModelBase
  {
    public ContactsViewModel(IMediator mediator) : base(mediator)
    {
    }

    public string Greeting => "Fake Contacts!";
  }
}
