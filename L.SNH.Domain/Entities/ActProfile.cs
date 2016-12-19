using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class ActProfile : BaseEntity<TimeSpan>
    {
        public virtual Act Act { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }

        public override bool Equals(object obj)
        {
            ActProfile ActProfile = (ActProfile)obj;
            if (ActProfile != null)
            {
                if (ActProfile.Username == this.Username && ActProfile.Act == this.Act)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int i = 0;
            i = this.Act.Id.GetHashCode() + this.Username.GetHashCode();
            return i;
        }
    }
}
