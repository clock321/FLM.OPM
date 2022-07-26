﻿using OPM.Core;
using MediatR;

namespace OPM.Modules.Message.ViewModels
{
  public class MessageViewModel : ViewModelBase
  {
    public MessageViewModel(IMediator mediator) : base(mediator)
    {
    }
    public string Greeting => "Welcome to Avalonia!";
  }
}
