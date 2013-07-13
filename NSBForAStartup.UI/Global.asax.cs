using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NSBForAStartup.AccountsService.Commands;
using NServiceBus;

namespace NSBForAStartup
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static IBus Bus { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetupNServiceBus();
        }



        private void SetupNServiceBus()
        {
            Configure.Transactions.Enable();
            Configure.Serialization.Xml();

            Bus = 
                 Configure.With()
                .DefineEndpointName("NSBForAStartup")
                .DefaultBuilder()
                .UseTransport<Msmq>()
                .PurgeOnStartup(true)
                .UnicastBus()
                .RunHandlersUnderIncomingPrincipal(true)
                .CreateBus()
                .Start(() =>
                {
                    Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install();
                });



        }

    }
}