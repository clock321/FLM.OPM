using OPM.Core;
using MediatR;

namespace OPM.Modules.SampleFooter.ViewModels
{
  public class SampleFooterViewModel : ViewModelBase
  {
    public SampleFooterViewModel(IMediator mediator) : base(mediator)
    {

    }

    public string Message => "Hello footer";
  }
}
