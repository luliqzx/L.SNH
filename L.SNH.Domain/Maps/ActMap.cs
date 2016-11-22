﻿using FluentNHibernate.Mapping;
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
            this.Map(x => x.Username);
            this.Map(x => x.Password);
            this.Map(x => x.Address);

            this.HasMany(x => x.OtherAddress).Cascade.All();

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
