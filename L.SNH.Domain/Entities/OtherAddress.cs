using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class OtherAddress : BaseEntity<string>
    {
        public virtual string Address { get; set; }
        public virtual string Country { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }

        public virtual Act Act { get; set; }
    }
}
