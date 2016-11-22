using FluentNHibernate.Mapping;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Maps
{
    public class OtherAddressMap : ClassMap<OtherAddress>
    {
        public OtherAddressMap()
        {
            this.Id(x => x.Id).GeneratedBy.Assigned();
            this.Map(x => x.Address);
            this.Map(x => x.Country);
            this.Map(x => x.Region);
            this.Map(x => x.PostalCode);

            this.References(x => x.Act);

            #region Audit Trail

            this.Map(x => x.CreateBy);
            this.Map(x => x.CreateDate);
            this.Map(x => x.CreateTerminal);
            this.Map(x => x.UpdateBy);
            this.Map(x => x.UpdateDate);
            this.Map(x => x.UpdateTerminal);

            //this.Version(x => x.Version).CustomType<int>().Generated.Always();
            #endregion
        }
    }
}
