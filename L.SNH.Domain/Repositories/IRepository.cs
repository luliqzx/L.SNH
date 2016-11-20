using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Save(T Ent);
        T Update(T Ent);
        void Delete(T Ent);
    }
}
