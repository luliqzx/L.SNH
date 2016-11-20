using FluentNHibernate.Mapping;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Maps
{
    public class ActMap : ClassMap<Act>
    {
        public ActMap()
        {
            this.Id(x => x.Id).GeneratedBy.Assigned(x => x.AddParam("Id", "0000000000"));
            this.Map(x => x.Name);
            this.Map(x => x.Username);
            this.Map(x => x.Password);
            this.Map(x => x.CreateDate).Default(DateTime.Now.ToString());
        }
    }
}
