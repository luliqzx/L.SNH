using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace L.SNH.Web.Common
{
    public class SimpleInjectorControllerFactory : DefaultControllerFactory
    {
        public IDictionary<Type, InstanceProducer> Producers { get; set; }
        protected override IController GetControllerInstance(RequestContext rc, Type type)
        {
            return (IController)this.Producers[type].GetInstance();
        }
    }
}