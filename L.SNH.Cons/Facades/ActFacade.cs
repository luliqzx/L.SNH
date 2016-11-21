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
    public interface IActFacade
    {
        void Create();

        void Update();

        void Delete();

        void TestAll();
    }
    public class ActFacade : IActFacade
    {
        private IActRepository ActRepo { get; set; }
        private IUnitOfWork UnitOfWork { get; set; }

        public ActFacade(IActRepository _ActRepo, IUnitOfWork _UnitOfWork)
        {
            this.ActRepo = _ActRepo;
            this.UnitOfWork = _UnitOfWork;
        }

        public void Create()
        {
            Act Act = new Act();
            Act.Id = "test";
            Act.Name = "test";
            Act.Username = "test";
            Act.CreateDate = DateTime.Now;
            UnitOfWork.BeginTransaction();
            this.ActRepo.Save(Act);
            UnitOfWork.Commit();


        }


        public void Update()
        {
            Act Act = this.ActRepo.GetBy(x => x.Id == "test");
            Act.Password = "test";
            UnitOfWork.BeginTransaction();
            this.ActRepo.Update(Act);
            UnitOfWork.Commit();
        }

        public void Delete()
        {
            Act Act = this.ActRepo.GetBy(x => x.Id == "test");
            UnitOfWork.BeginTransaction();
            this.ActRepo.Delete(Act);
            UnitOfWork.Commit();
        }


        public void TestAll()
        {
            Act Act = new Act();
            Act.Id = "test";
            Act.Name = "test";
            Act.Username = "test";
            Act.CreateDate = DateTime.Now;
            UnitOfWork.BeginTransaction();
            this.ActRepo.Save(Act);
            Act = this.ActRepo.GetBy(x => x.Id == "test");
            Act.Password = "test";
            this.ActRepo.Update(Act);
            Act = this.ActRepo.GetBy(x => x.Id == "test");
            this.ActRepo.Delete(Act);
            UnitOfWork.Commit();
        }
    }
}
