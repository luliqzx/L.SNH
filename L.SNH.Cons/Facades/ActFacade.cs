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
        private IPrivilegeRepository PrivilegeRepository { get; set; }
        public ActFacade(IActRepository _ActRepo, IUnitOfWork _UnitOfWork, IPrivilegeRepository _PrivilegeRepository)
        {
            this.ActRepo = _ActRepo;
            this.UnitOfWork = _UnitOfWork;
            this.PrivilegeRepository = _PrivilegeRepository;
        }

        public void Create()
        {
            Act Act = new Act();
            Act.Id = "user1";
            Act.Name = "user1";
            Act.Profile = new ActProfile() { Id = DateTime.Now.TimeOfDay, Username = "user1", Password = "user1", Address = "user1", Email = "user1", Act = Act };
            Act.CreateDate = DateTime.Now;
            Act.Type = "User";

            Act.Groups = new List<Act>();
            Act.Groups.Add(new Act { Id = "Admin", Type = "Role" });
            Act.Groups.Add(new Act { Id = "User", Type = "Role" });
            Act.Groups.Add(new Act { Id = "Contribute", Type = "Role" });


            Act.Groups[0].Menus = new List<GroupMenu>();

            Privilege Privilege = this.PrivilegeRepository.GetBy(x => x.Id == "Save");
            if (Privilege == null)
            {
                Privilege = new Privilege();
                Privilege.Id = "Save";
                this.UnitOfWork.BeginTransaction();
                this.PrivilegeRepository.Save(Privilege);
                this.UnitOfWork.Commit();
            }

            GroupMenu GroupMenu = new GroupMenu();
            GroupMenu.Privileges = new List<Privilege>();
            GroupMenu.Privileges.Add(Privilege);

            Act.Groups[0].Menus.Add(GroupMenu);

            //Act.Child = new List<Act>();
            //Act.Child.Add(new Act { });
            //Act.Child.Add(new Act { });
            //Act.Child.Add(new Act { });

            UnitOfWork.BeginTransaction();
            this.ActRepo.Save(Act);
            UnitOfWork.Commit();


        }


        public void Update()
        {
            Act Act = this.ActRepo.GetBy(x => x.Id == "test");
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
            Act.Profile = new ActProfile() { Username = "user1", Password = "user1", Address = "user1", Email = "user1" };
            Act.CreateDate = DateTime.Now;
            UnitOfWork.BeginTransaction();
            this.ActRepo.Save(Act);
            Act = this.ActRepo.GetBy(x => x.Id == "test");
            this.ActRepo.Update(Act);
            Act = this.ActRepo.GetBy(x => x.Id == "test");
            this.ActRepo.Delete(Act);
            UnitOfWork.Commit();
        }
    }
}
