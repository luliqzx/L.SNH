using L.SNH.Domain.Entities;
using L.SNH.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Cons.Facades
{
    public interface IDefaultFacade
    {
        void Delete();
        void Save();
        void Update();
        void Get();
    }

    public class DefaultFacade : IDefaultFacade
    {
        protected ICountRepository CountRepo;
        public DefaultFacade(ICountRepository _countRepo)
        {
            this.CountRepo = _countRepo;
        }

        public void Delete()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = this.CountRepo.GetBy(x => x.Id == CompositeCounter);
            this.CountRepo.Delete(Counter);
        }

        public void Save()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = new Counter();
            Counter.Id = CompositeCounter;
            Counter._Counter = 1;
            Counter.CreateBy = "TEST";
            Counter.CreateDate = DateTime.Now;
            Counter.CreateTerminal = "::1";

            Counter.UpdateBy = "TEST";
            Counter.UpdateDate = DateTime.Now;
            Counter.UpdateTerminal = "::1";

            this.CountRepo.Save(Counter);
        }

        public void Update()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = this.CountRepo.GetBy(x => x.Id == CompositeCounter);
            Counter._Counter = Counter._Counter + 212;
            this.CountRepo.Update(Counter);
        }

        public void Get()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = this.CountRepo.GetBy(x => x.Id == CompositeCounter);
        }
    }
}
