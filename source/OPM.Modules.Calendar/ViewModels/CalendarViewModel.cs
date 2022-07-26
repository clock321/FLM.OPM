using OPM.Core;
using MediatR;

namespace OPM.Modules.Calendar.ViewModels
{
  public class CalendarViewModel : ViewModelBase
  {
    public CalendarViewModel(IMediator mediator) : base(mediator)
    {
    }

    public string Greeting => "Welcome to Avalonia!";
  }
}
