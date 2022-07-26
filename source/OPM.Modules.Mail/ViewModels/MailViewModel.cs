﻿using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Regions;
using OPM.Core;
using OPM.Modules.Mail.Models;
using OPM.Modules.Mail.Services;
using MediatR;

namespace OPM.Modules.Mail.ViewModels
{
  public class MailViewModel : ViewModelBase
  {
    private IMailService _mailService;
    private IRegionManager _regionManager;

    public MailViewModel(IMediator mediator, IMailService mailService, IRegionManager regionManager) : base(mediator)
    {
      _regionManager = regionManager;
      _mailService = mailService;
      MailMessages = new ObservableCollection<MailMessage>(_mailService.Messages);
    }

    public DelegateCommand CommandShowDashboard => new DelegateCommand(OnShowDashboard);

    public string Greeting => "Mail Region";

    public ObservableCollection<MailMessage> MailMessages { get; private set; }

    private void OnShowDashboard()
    {
      _regionManager.RequestNavigate(RegionNames.ContentRegion, "DashboardView");
    }
  }
}
