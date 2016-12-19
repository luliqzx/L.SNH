using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class Counter : BaseEntity<string>
    {
        public virtual int Year { get; set; }
        public virtual int Month { get; set; }
        public virtual string CounterType { get; set; }

        public virtual int _Counter { get; set; }
        public virtual string _DefaultCounter
        {
            get
            {
                return string.Format(@"{0}{1}{2}{3}", CounterType, Year, Month.ToString().PadLeft(2, '0'), _Counter.ToString().PadLeft(4, '0'));
            }
        }

        public override bool Equals(object obj)
        {
            Counter Counter = (Counter)obj;
            if (Counter != null)
            {
                if (Counter.CounterType == this.CounterType && Counter.Month == this.Month && Counter.Year == this.Year)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int i = 0;
            i = this.Year.GetHashCode() + this.Month.GetHashCode() + this.CounterType.GetHashCode();
            return i;
        }

        public class CompositeCounter
        {
            public virtual int Year { get; set; }
            public virtual int Month { get; set; }
            public virtual string CounterType { get; set; }
        }
    }
}
