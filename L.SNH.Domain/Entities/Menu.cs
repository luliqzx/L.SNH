using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class Menu : BaseEntity<string>
    {
        public virtual string Name { get; set; }
        public virtual string Path { get; set; }
        public virtual int Position { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Public { get; set; }
        public virtual bool Active { get; set; }
        public virtual string ImageUrl { get; set; }
        #region Navigate
        public virtual Menu MainMenu { get; set; }
        public virtual IList<Menu> ChildMenu { get; set; }
        #endregion Navigate
    }
}
