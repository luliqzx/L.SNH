using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Entities
{
    public class Counter : BaseEntity<Counter.CompositeCounter>
    {
        public virtual int Year { get { return this.Id.Year; } set { this.Id.Year = value; } }
        public virtual int Month { get { return this.Id.Month; } set { this.Id.Month = value; } }
        public virtual string CounterType { get { return this.Id.CounterType; } set { this.Id.CounterType = value; } }

        public virtual int _Counter { get; set; }
        public virtual string _DefaultCounter
        {
            get
            {
                return string.Format(@"{0}{1}{2}{3}", Id.CounterType, Id.Year, Id.Month.ToString().PadLeft(2, '0'), _Counter.ToString().PadLeft(4, '0'));
            }
        }

        public override bool Equals(object obj)
        {
            Counter Counter = (Counter)obj;
            if (Counter != null)
            {
                if (Counter.Id.CounterType == this.Id.CounterType && Counter.Id.Month == this.Id.Month && Counter.Id.Year == this.Id.Year)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int i = 0;
            i = this.Id.Year.GetHashCode() + this.Id.Month.GetHashCode() + this.Id.CounterType.GetHashCode();
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
