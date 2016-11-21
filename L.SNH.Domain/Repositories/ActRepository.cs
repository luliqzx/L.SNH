using L.SNH.Domain.Common;
using L.SNH.Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Repositories
{
    public interface IActRepository : IRepository<Act>
    {
    }

    public class ActRepository : Repository<Act>, IActRepository
    {
        public ActRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }
    }
}
