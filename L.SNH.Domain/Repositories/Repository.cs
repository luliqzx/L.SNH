using L.SNH.Domain.Common;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private UnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public Repository() : base(_unitOfWork) { }

        protected ISession Session { get { return _unitOfWork.Session; } }


        public T Save(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public T Update(T entity)
        {
            Session.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }
    }
}
