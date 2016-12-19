using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class Privilege : BaseEntity<string>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
