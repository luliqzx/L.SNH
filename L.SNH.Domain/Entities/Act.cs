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
        public virtual bool Active { get; set; }
        public virtual string Type { get; set; }
        public virtual ActProfile Profile { get; set; }

        public virtual IList<OtherAddress> OtherAddress { get; set; }
        public virtual IList<Act> Groups { get; set; }
        //public virtual IList<Act> Child { get; set; }

        public virtual IList<GroupMenu> Menus { get; set; }
    }
}
