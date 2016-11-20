using L.SNH.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Cons.Facades
{
    public interface IActFacade
    {
        void Test();
    }
    public class ActFacade : IActFacade
    {
        private IActRepository ActRepo { get; set; }

        public ActFacade(IActRepository _ActRepo)
        {
            this.ActRepo = _ActRepo;
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
