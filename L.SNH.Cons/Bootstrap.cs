using L.SNH.Cons.Facades;
using L.SNH.Domain.Common;
using L.SNH.Domain.Entities;
using L.SNH.Domain.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Cons
{
    class Bootstrap
    {
        public static void Start(Container container)
        {
            // 1. Create a new Simple Injector container

            // 2. Configure the container (register)
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);
            container.Register<IActFacade, ActFacade>(Lifestyle.Singleton);
            container.Register<IActRepository, ActRepository>(Lifestyle.Singleton);
            container.Register<ICountRepository, CountRepository>(Lifestyle.Singleton);
            container.Register<IDefaultFacade, DefaultFacade>(Lifestyle.Singleton);

            // 3. Optionally verify the container's configuration.
            container.Verify();

        }
    }
}
