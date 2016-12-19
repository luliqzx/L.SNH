using FluentNHibernate.Mapping;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Maps
{
    public class CounterMap : ClassMap<Counter>
    {
        public CounterMap()
        {
            this.CompositeId()
                .KeyProperty(x => x.Year)
                .KeyProperty(x => x.Month)
                .KeyProperty(x => x.CounterType);
            this.Map(x => x._Counter);

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
