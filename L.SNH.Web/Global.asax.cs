using L.SNH.Domain.Common;
using L.SNH.Domain.Repositories;
using L.SNH.Web.Common;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace L.SNH.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new Container();
            Start(container);
        }

        private void Start(Container container)
        {

            //var controllerTypes = SimpleInjectorMvcExtensions.GetControllerTypesToRegister(container, Assembly.GetExecutingAssembly());

            //var controllerProducers = controllerTypes
            //    .ToDictionary(type => type, type => CreateControllerProducer(container, type));

            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            //container.Register<IActRepository, ActRepository>(Lifestyle.Scoped);

            //// Verify after creating the controller producers.
            //container.Verify();

            //ControllerBuilder.Current.SetControllerFactory(
            //    new SimpleInjectorControllerFactory { Producers = controllerProducers });

            // 1. Create a new Simple Injector container
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // 2. Configure the container (register)
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IActRepository, ActRepository>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // 3. Optionally verify the container's configuration.
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static InstanceProducer CreateControllerProducer(Container c, Type type)
        {
            var producer = Lifestyle.Transient.CreateProducer(typeof(IController), type, c);
            producer.Registration.SuppressDiagnosticWarning(
                DiagnosticType.DisposableTransientComponent,
                "MVC disposes the controller when the web request ends.");
            return producer;
        }
    }
}
