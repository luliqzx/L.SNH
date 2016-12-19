using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class GroupMenu
    {
        public virtual Act Act { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual IList<Privilege> Privileges { get; set; }

        public override bool Equals(object obj)
        {
            GroupMenu ActMenu = (GroupMenu)obj;
            if (ActMenu != null)
            {
                if (ActMenu.Act == this.Act && ActMenu.Menu == this.Menu)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int i = 0;
            i = this.Act.Id.GetHashCode() + this.Menu.Id.GetHashCode();
            return i;
        }
    }
}
