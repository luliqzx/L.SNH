using L.SNH.Cons.Facades;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Cons
{
    class Program
    {
        static IActFacade actFacade { get; set; }
        static IDefaultFacade counterFacade { get; set; }

        static void Main(string[] args)
        {
            var container = new Container();
            Bootstrap.Start(container);
            actFacade = container.GetInstance<IActFacade>();
            //actFacade.Create();
            //actFacade.Update();
            //actFacade.Delete();
            //actFacade.TestAll();

            counterFacade = container.GetInstance<IDefaultFacade>();

            counterFacade.Delete();
            counterFacade.Save();
            counterFacade.Update();
            counterFacade.Get();
        }
    }
}
