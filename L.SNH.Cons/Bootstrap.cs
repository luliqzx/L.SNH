﻿using L.SNH.Cons.Facades;
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
            container.Register<IActFacade, ActFacade>(Lifestyle.Singleton);
            container.Register<IActRepository, ActRepository>(Lifestyle.Singleton);

            // 3. Optionally verify the container's configuration.
            container.Verify();

        }
    }
}
