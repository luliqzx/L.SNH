using L.SNH.Domain.Common;
using L.SNH.Domain.Entities;
using L.SNH.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L.SNH.Web.Controllers
{
    public class TestController : Controller
    {
        public IActRepository ActRepo { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public TestController(IActRepository _ActRepo, IUnitOfWork _UnitOfWork)
        {
            this.ActRepo = _ActRepo;
            this.UnitOfWork = _UnitOfWork;
        }

        // GET: Test
        public ActionResult Index2()
        {
            UnitOfWork.BeginTransaction();
            Act Act = this.ActRepo.GetBy(x => x.Id == "testweb");
            if (Act != null)
            {
                this.ActRepo.Delete(Act);
            }

            Act = new Act();
            Act.Id = "testweb";
            Act.Name = "testweb";
            //Act.Username = "testweb";
            Act.CreateDate = DateTime.Now;
            Act.UpdateDate = DateTime.Now;
            Act.OtherAddress = new List<OtherAddress>();
            Act.OtherAddress.Add(new OtherAddress { Id = "Addr1", Address = "Addr1", CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            Act.OtherAddress.Add(new OtherAddress { Id = "Addr2", Address = "Addr2", CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            this.ActRepo.Save(Act);

            Act = this.ActRepo.GetBy(x => x.Id == "testweb");
            //Act.Password = "testweb";
            //Act.Address = "Prime";
            Act.OtherAddress.Remove(Act.OtherAddress[1]);
            Act.OtherAddress.Add(new OtherAddress { Id = "Addr3", Address = "Addr3", CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            this.ActRepo.Update(Act);
            UnitOfWork.Commit();

            return View("Index");
        }

        public ActionResult Index()
        {
            Act Act = this.ActRepo.GetBy(x => x.Id == "testweb");
            UnitOfWork.BeginTransaction();
            this.ActRepo.Delete(Act);
            UnitOfWork.Commit();

            Act = new Act();
            Act.Id = "testweb";
            Act.Name = "testweb";
            //Act.Username = "testweb";
            Act.CreateDate = DateTime.Now;
            UnitOfWork.BeginTransaction();
            this.ActRepo.Save(Act);
            UnitOfWork.Commit();

            Act = this.ActRepo.GetBy(x => x.Id == "testweb");
            //Act.Password = "testweb";
            UnitOfWork.BeginTransaction();
            this.ActRepo.Update(Act);
            UnitOfWork.Commit();


            return View();
        }
    }


}