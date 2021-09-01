using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Common
{
    [Serializable]
    public class TicksTime : IPreSave, IPostLoad
    {
        public long ticks;
        private DateTime value;

        public void PreSave() {
            this.ticks = this.value.Ticks;
        }

        public void PostLoad() {
            this.value = new DateTime(this.ticks);
        }

        public static TimeSpan operator -(TicksTime a, TicksTime b) { return a.value - b.value; }
        public static bool operator ==(TicksTime a, TicksTime b) => a.value == b.value;
        public static bool operator !=(TicksTime a, TicksTime b) => a.value != b.value;
        public static bool operator <(TicksTime a, TicksTime b) => a.value < b.value;
        public static bool operator <=(TicksTime a, TicksTime b) => a.value <= b.value;
        public static bool operator >(TicksTime a, TicksTime b) => a.value > b.value;
        public static bool operator >=(TicksTime a, TicksTime b) => a.value >= b.value;

        public static TimeSpan operator -(TicksTime a, DateTime b) { return a.value - b; }
        public static TimeSpan operator -(DateTime a, TicksTime b) { return a - b.value; }
        public static bool operator ==(TicksTime a, DateTime b) => a.value == b;
        public static bool operator !=(TicksTime a, DateTime b) => a.value != b;
        public static bool operator <(TicksTime a, DateTime b) => a.value < b;
        public static bool operator <=(TicksTime a, DateTime b) => a.value <= b;
        public static bool operator >(TicksTime a, DateTime b) => a.value > b;
        public static bool operator >=(TicksTime a, DateTime b) => a.value >= b;
        public static bool operator ==(DateTime a, TicksTime b) => a == b.value;
        public static bool operator !=(DateTime a, TicksTime b) => a != b.value;
        public static bool operator <(DateTime a, TicksTime b) => a < b.value;
        public static bool operator <=(DateTime a, TicksTime b) => a <= b.value;
        public static bool operator >(DateTime a, TicksTime b) => a > b.value;
        public static bool operator >=(DateTime a, TicksTime b) => a >= b.value;

        public static TicksTime operator +(TicksTime a, TimeSpan b) { a.value += b; return a; }
        public static TicksTime operator -(TicksTime a, TimeSpan b) { a.value -= b; return a; }

        public static implicit operator DateTime(TicksTime a) => a.value;
        public static implicit operator TicksTime(DateTime a) => new TicksTime() { value = a };

        public override string ToString() => this.value.ToString();

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
