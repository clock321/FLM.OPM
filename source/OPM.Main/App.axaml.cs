using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FluentValidation;
using MediatR;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using OPM.Core;
using OPM.Data;
using OPM.Main.Core.RegionAdapters;
using OPM.MediatR.PipeLineBehavior;
using OPM.Modules.Calendar;
using OPM.Modules.Contacts;
using OPM.Modules.Mail;
using OPM.Modules.Message;
using OPM.Modules.SampleFooter;
using OPM.Repository;
using OPM.Styles.Themes;
using OPM.ViewModels;
using OPM.Views;
using Unity;
using Unity.Lifetime;
using OPM.Data.Dto;
using OPM.Pages;
using OPM.PageModels;
using Avalonia.Platform;
using Avalonia.Extensions.Controls;

namespace OPM
{
  public class App : PrismApplication
  {
    bool IsDevelopmentEnv = false;
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);

      var OPM_ENVIRONMENT=  Environment.GetEnvironmentVariable("OPM_ENVIRONMENT");
      if(OPM_ENVIRONMENT!=null&& OPM_ENVIRONMENT.ToLower()== "development")
      {
        IsDevelopmentEnv = true;
      }

      AppConfigurations.InitAppConfiguration(IsDevelopmentEnv);


      //主题
      Styles.Add(new DarkTheme());


      base.Initialize();
    }


    protected override void OnInitialized()
    {
      // 将视图注册到它将出现的区域,不要在ViewModel中注册它们。
      var regionManager = Container.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DashboardView));


      //Test
      var userInfoToken = Container.Resolve<UserInfoToken>();
      userInfoToken.Id = Guid.Parse("4b352b37-332a-40c6-ab05-e38fcf109719");
      userInfoToken.Email = "czhcom@163.com";


      //using (var context = new OPMContext())
      //{
      //  context.Database.EnsureCreated();

      //  context.UserAccount.Add(new UserAccount {
      //    UserID = 0,
      //    RoleID = 0,
      //    StaffID = 0,
      //    StudentID = 0,
      //    EmailAddress = "czhcom@163.com",
      //    UserName = "admin",
      //    Password = "123456",
      //    AccountStatus = "",
      //    CreatedDate = DateTime.Now,
      //    CreatedBy = Guid.NewGuid(),
      //    ModifiedDate = DateTime.Now,
      //    ModifiedBy = Guid.NewGuid(),
      //    DeletedDate = DateTime.Now,
      //    DeletedBy = Guid.NewGuid(),
      //    IsDeleted = false
      //  });

      //  context.SaveChanges();
      //}

    }

    protected override IAvaloniaObject CreateShell()
    {
      return this.Container.Resolve<MainWindow>();
    }


    protected override void RegisterTypes(IContainerRegistry crg)
    {
      var container = crg.GetContainer();

      // Services
      var services = new ServiceCollection();
      services.AddLogging(logging => logging.AddConsole());
      using (var provider = services.BuildServiceProvider())
      {
        //var app = provider.GetService<Avalonia.Application>();
        //var builder = AppBuilder.Configure(app);
      };

      AvaloniaLocator.CurrentMutable.Bind<IFontManagerImpl>().ToConstant(new FontManagerImpl());

      //注册MediatR
      var assembly = AppDomain.CurrentDomain.Load("OPM.MediatR");
      container.RegisterMediator(new HierarchicalLifetimeManager());
      container.RegisterMediatorHandlers(assembly);
      container.RegisterType(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), "ValidationBehavior");


      crg.RegisterSingleton<UserInfoToken>();

      crg.RegisterSingleton<AccessTokenSingleton>();
      crg.Register<Core.Http.HttpClientBase>();
      crg.Register<Core.Http.AbpHttpClientBase>();

      //注册AutoMapper
      crg.RegisterInstance(MapperConfig.GetMapperConfigs());

      //注册ILogger
      crg.Register(typeof(ILogger<>), typeof(Logger<>));
      crg.Register<ILoggerFactory, LoggerFactory>();


      //注册UnitOfWork
      crg.Register(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
      crg.Register<IPropertyMappingService, PropertyMappingService>();
      crg.Register<ILoginAuditRepository, LoginAuditRepository>();
      crg.Register<INLogRespository, NLogRespository>();
      crg.Register<IUserNotificationRepository, UserNotificationRepository>();


      //注册 Views - Generic
      crg.Register<MainWindow>();
      crg.Register<StackPanelRegionAdapter>();
      crg.Register<GridRegionAdapter>();


      //注册 Views - Region Navigation
      crg.RegisterForNavigation<MainWindow, MainWindowViewModel>();
      crg.RegisterForNavigation<MainTabView, MainTabViewModel>();
      crg.RegisterForNavigation<DashboardView, DashboardViewModel>();
      crg.RegisterForNavigation<SettingsView, SettingsViewModel>();

      crg.RegisterForNavigation<LoginPage, LoginViewModel>("登录");
      //crg.RegisterForNavigation<NavigationView, NavigationViewModel>();

    }


    /// <summary>
    /// 配置模块
    /// </summary>
    /// <param name="moduleCatalog"></param>
    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      base.ConfigureModuleCatalog(moduleCatalog);

      moduleCatalog.AddModule<MailModule>();
      moduleCatalog.AddModule<MessageModule>();
      moduleCatalog.AddModule<ContactsModule>();
      moduleCatalog.AddModule<CalendarModule>();
      moduleCatalog.AddModule<SampleFooterModule>();
    }


    /// <summary>
    /// AdapterMapping
    /// </summary>
    /// <param name="regionAdapterMappings"></param>
    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
      base.ConfigureRegionAdapterMappings(regionAdapterMappings);
      regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
      regionAdapterMappings.RegisterMapping(typeof(Grid), Container.Resolve<GridRegionAdapter>());
    }

  }


  /// <summary>
  /// Container 扩展
  /// </summary>
  public static class ContainerExtensions
  {
    public static bool IsMediatorHandler(this Type arg)
    {
      return arg.GetInterfaces().Where(i => i.Name.StartsWith("IRequestHandler")).Any();
    }


    /// <summary>
    /// 注册MediatR
    /// </summary>
    /// <param name="container"></param>
    /// <param name="lifetimeManager"></param>
    /// <returns></returns>
    public static IUnityContainer RegisterMediator(this IUnityContainer container, ITypeLifetimeManager lifetimeManager)
    {
      return container.RegisterType<IMediator, Mediator>(lifetimeManager)
          .RegisterInstance<ServiceFactory>(type =>
          {
            var enumerableType = type
                  .GetInterfaces()
                  .Concat(new[] { type })
                  .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            return enumerableType != null
                  ? container.ResolveAll(enumerableType.GetGenericArguments()[0])
                  : container.IsRegistered(type)
                      ? container.Resolve(type)
                      : null;
          });

    }

    /// <summary>
    /// 注册MediatR Handler
    /// </summary>
    /// <param name="container"></param>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IUnityContainer RegisterMediatorHandlers(this IUnityContainer container, Assembly assembly)
    {
      return container.RegisterTypesImplementingType(assembly, typeof(IRequestHandler<,>))
          .RegisterNamedTypesImplementingType(assembly, typeof(INotificationHandler<>));
    }

    internal static bool IsGenericTypeOf(this Type type, Type genericType)
    {
      return type.IsGenericType &&
             type.GetGenericTypeDefinition() == genericType;
    }

    internal static void AddGenericTypes(this List<object> list, IUnityContainer container, Type genericType)
    {
      var genericHandlerRegistrations =
          container.Registrations.Where(reg => reg.RegisteredType == genericType);

      foreach (var handlerRegistration in genericHandlerRegistrations)
      {
        if (list.All(item => item.GetType() != handlerRegistration.MappedToType))
        {
          list.Add(container.Resolve(handlerRegistration.MappedToType));
        }
      }
    }

    /// <summary>
    /// 为提供的程序集注册给定类型的所有实现
    /// </summary>
    public static IUnityContainer RegisterTypesImplementingType(this IUnityContainer container, Assembly assembly, Type type)
    {
      foreach (var implementation in assembly.GetTypes().Where(t => t.GetInterfaces().Any(implementation => IsSubclassOfRawGeneric(type, implementation))))
      {
        var interfaces = implementation.GetInterfaces();
        foreach (var @interface in interfaces)
          container.RegisterType(@interface, implementation);
      }

      return container;
    }

    /// <summary>
    /// 为提供的程序集注册给定类型的所有实现.
    /// </summary>
    public static IUnityContainer RegisterNamedTypesImplementingType(this IUnityContainer container, Assembly assembly, Type type)
    {
      foreach (var implementation in assembly.GetTypes().Where(t => t.GetInterfaces().Any(implementation => IsSubclassOfRawGeneric(type, implementation))))
      {
        var interfaces = implementation.GetInterfaces();
        foreach (var @interface in interfaces)
          container.RegisterType(@interface, implementation, implementation.FullName);
      }

      return container;
    }

    /// <summary>
    /// 是否泛型子类
    /// </summary>
    /// <param name="generic"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
      while (toCheck != null && toCheck != typeof(object))
      {
        var currentType = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
        if (generic == currentType)
          return true;

        toCheck = toCheck.BaseType;
      }

      return false;
    }
  }
}