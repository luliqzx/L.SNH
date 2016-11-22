using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class Act : BaseEntity<string>
    {
        public virtual string Name { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<OtherAddress> OtherAddress { get; set; }

    }
}
