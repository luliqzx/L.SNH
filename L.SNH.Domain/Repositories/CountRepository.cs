using L.SNH.Domain.Common;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Repositories
{
    public interface ICountRepository : IRepository<Counter>
    {

    }
    public class CountRepository : Repository<Counter>, ICountRepository
    {
        public CountRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }
    }
}
