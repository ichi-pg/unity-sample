using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Common
{
    [Serializable]
    public struct TicksTime : IPreSave, IPostLoad, IComparable
    {
        public long ticks;
        private DateTime value;

        public void PreSave() {
            this.ticks = this.value.Ticks;
        }

        public void PostLoad() {
            this.value = new DateTime(this.ticks);
        }

        public override string ToString() => this.value.ToString();
        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj is TicksTime) {
                var i = (TicksTime)obj;
                return this == i;
            }
            if (obj is DateTime) {
                var i = (DateTime)obj;
                return this == i;
            }
            return false;
        }

        public int CompareTo(object obj) {
            if (obj == null) {
                return 0;
            }
            if (obj is TicksTime) {
                var i = (TicksTime)obj;
                return this < i ? -1 : this == i ? 0 : 1;
            }
            if (obj is DateTime) {
                var i = (DateTime)obj;
                return this < i ? -1 : this == i ? 0 : 1;
            }
            return 0;
        }

        //演算
        public static DateTime operator +(TicksTime a, TimeSpan b) => a.value + b;
        public static DateTime operator -(TicksTime a, TimeSpan b) => a.value - b;

        //演算(TimeSpan)
        public static TimeSpan operator -(TicksTime a, TicksTime b) => a.value - b.value;
        public static TimeSpan operator -(TicksTime a, DateTime b) => a.value - b;
        public static TimeSpan operator -(DateTime a, TicksTime b) => a - b.value;

        //比較
        public static bool operator ==(TicksTime a, TicksTime b) => a.value == b.value;
        public static bool operator !=(TicksTime a, TicksTime b) => a.value != b.value;
        public static bool operator <(TicksTime a, TicksTime b) => a.value < b.value;
        public static bool operator <=(TicksTime a, TicksTime b) => a.value <= b.value;
        public static bool operator >(TicksTime a, TicksTime b) => a.value > b.value;
        public static bool operator >=(TicksTime a, TicksTime b) => a.value >= b.value;

        //比較(DateTime)
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

        //キャスト
        public static implicit operator DateTime(TicksTime a) => a.value;
        public static implicit operator TicksTime(DateTime a) => new TicksTime() { value = a };
    }
}
