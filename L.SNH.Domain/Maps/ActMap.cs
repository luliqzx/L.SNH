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
            this.Id(x => x.Id).GeneratedBy.Assigned();
            this.Map(x => x.Name);
            this.HasOne(x => x.Profile).Cascade.All();
            this.HasMany(x => x.OtherAddress).Cascade.All();
            this.HasManyToMany(x => x.Groups).Table("UserGroup").ParentKeyColumn("ActId").ChildKeyColumn("GroupId").Cascade.All();

            #region Audit Trail

            this.Map(x => x.CreateBy);
            this.Map(x => x.CreateDate);
            this.Map(x => x.CreateTerminal);
            this.Map(x => x.UpdateBy);
            this.Map(x => x.UpdateDate);
            this.Map(x => x.UpdateTerminal);
            this.Version(x => x.Version).CustomType<int>();

            #endregion

            this.Map(x => x.Type);

            this.HasMany(x => x.Menus).KeyColumn("ActId");
        }
    }
}
