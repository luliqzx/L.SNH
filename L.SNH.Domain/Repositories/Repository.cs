using L.SNH.Domain.Common;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Linq.Expressions;

namespace L.SNH.Domain.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected IUnitOfWork _unitOfWork { get; set; }
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public Repository()
        {
        }

        protected ISession Session
        {
            get
            {
                if (!_unitOfWork.Session.IsOpen)
                {
                    _unitOfWork.Session = _unitOfWork.CreateSession();
                }
                return _unitOfWork.Session;
            }
        }

        public virtual T Save(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            Session.Update(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public virtual T GetBy(Expression<Func<T, bool>> expr)
        {
            return Session.Query<T>().FirstOrDefault(expr);
        }
    }
}
