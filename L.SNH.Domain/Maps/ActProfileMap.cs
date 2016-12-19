using FluentNHibernate.Mapping;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Maps
{
    public class ActProfileMap : ClassMap<ActProfile>
    {
        public ActProfileMap()
        {
            this.Id(x => x.Id).GeneratedBy.Assigned();
            this.References(x => x.Act, "ActId");
            //this.Map(x => x.Username);

            //this.CompositeId()
            //    .KeyProperty(x => x.Id)
            //    .KeyProperty(x => x.Username);

            //this.References(x => x.Act, "Id");

            this.Map(x => x.Username);

            this.Map(x => x.Password);
            this.Map(x => x.Email);
            this.Map(x => x.Address);

            #region Audit Trail

            this.Map(x => x.CreateBy);
            this.Map(x => x.CreateDate);
            this.Map(x => x.CreateTerminal);
            this.Map(x => x.UpdateBy);
            this.Map(x => x.UpdateDate);
            this.Map(x => x.UpdateTerminal);
            this.Version(x => x.Version).CustomType<int>();

            #endregion
        }
    }
}
