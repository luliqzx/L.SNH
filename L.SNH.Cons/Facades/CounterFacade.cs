using L.SNH.Domain.Common;
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

    public class CounterFacade : IDefaultFacade
    {
        protected ICountRepository CountRepo;
        private IUnitOfWork UnitOfWork { get; set; }
        public CounterFacade(ICountRepository _countRepo, IUnitOfWork _UnitOfWork)
        {
            this.CountRepo = _countRepo;
            this.UnitOfWork = _UnitOfWork;
        }

        public void Delete()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = this.CountRepo.GetBy(x => x.Year == CompositeCounter.Year && x.Month == CompositeCounter.Month && x.CounterType == CompositeCounter.CounterType);
            if (Counter!= null)
            {
                this.UnitOfWork.BeginTransaction();
                this.CountRepo.Delete(Counter);
                this.UnitOfWork.Commit();
            }
        }

        public void Save()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = new Counter();
            Counter.Year = CompositeCounter.Year;
            Counter.Month = CompositeCounter.Month;
            Counter.CounterType = CompositeCounter.CounterType;
            Counter._Counter = 1;
            Counter.CreateBy = "TEST";
            Counter.CreateDate = DateTime.Now;
            Counter.CreateTerminal = "::1";

            Counter.UpdateBy = "TEST";
            Counter.UpdateDate = DateTime.Now;
            Counter.UpdateTerminal = "::1";

            this.UnitOfWork.BeginTransaction();
            this.CountRepo.Save(Counter);
            this.UnitOfWork.Commit();
        }

        public void Update()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = this.CountRepo.GetBy(x => x.Year == CompositeCounter.Year && x.Month == CompositeCounter.Month && x.CounterType == CompositeCounter.CounterType);
            Counter._Counter = Counter._Counter + 212;
            this.UnitOfWork.BeginTransaction();
            this.CountRepo.Update(Counter);
            this.UnitOfWork.Commit();
        }

        public void Get()
        {
            Counter.CompositeCounter CompositeCounter = new Counter.CompositeCounter();
            CompositeCounter.Year = DateTime.Now.Year;
            CompositeCounter.Month = DateTime.Now.Month;
            CompositeCounter.CounterType = "DEF";
            Counter Counter = this.CountRepo.GetBy(x => x.Year == CompositeCounter.Year && x.Month == CompositeCounter.Month && x.CounterType == CompositeCounter.CounterType);
        }
    }
}
