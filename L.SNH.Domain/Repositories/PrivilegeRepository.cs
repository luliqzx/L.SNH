using L.SNH.Domain.Common;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Repositories
{
    public interface IPrivilegeRepository : IRepository<Privilege>
    {
    }
    public class PrivilegeRepository : Repository<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = (UnitOfWork)UnitOfWork;
        }
    }
}
