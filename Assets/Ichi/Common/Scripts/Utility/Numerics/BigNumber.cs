using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Common
{
    [Serializable]
    public class BigNumber : IPreSave, IPostLoad
    {
        public string s;
        private BigInteger value;

        public void PreSave() {
            this.s = this.value.ToString();
        }

        public void PostLoad() {
            this.value = BigInteger.Parse(this.s);
        }

        public static BigNumber operator +(BigNumber a, BigNumber b) { a.value += b.value; return a; }
        public static BigNumber operator -(BigNumber a, BigNumber b) { a.value -= b.value; return a; }
        public static BigNumber operator *(BigNumber a, BigNumber b) { a.value *= b.value; return a; }
        public static BigNumber operator /(BigNumber a, BigNumber b) { a.value /= b.value; return a; }
        public static bool operator ==(BigNumber a, BigNumber b) => a.value == b.value;
        public static bool operator !=(BigNumber a, BigNumber b) => a.value != b.value;
        public static bool operator <(BigNumber a, BigNumber b) => a.value < b.value;
        public static bool operator <=(BigNumber a, BigNumber b) => a.value <= b.value;
        public static bool operator >(BigNumber a, BigNumber b) => a.value > b.value;
        public static bool operator >=(BigNumber a, BigNumber b) => a.value >= b.value;

        public static BigNumber operator +(BigNumber a, BigInteger b) { a.value += b; return a; }
        public static BigNumber operator -(BigNumber a, BigInteger b) { a.value -= b; return a; }
        public static BigNumber operator *(BigNumber a, BigInteger b) { a.value *= b; return a; }
        public static BigNumber operator /(BigNumber a, BigInteger b) { a.value /= b; return a; }
        public static bool operator ==(BigNumber a, BigInteger b) => a.value == b;
        public static bool operator !=(BigNumber a, BigInteger b) => a.value != b;
        public static bool operator <(BigNumber a, BigInteger b) => a.value < b;
        public static bool operator <=(BigNumber a, BigInteger b) => a.value <= b;
        public static bool operator >(BigNumber a, BigInteger b) => a.value > b;
        public static bool operator >=(BigNumber a, BigInteger b) => a.value >= b;
        public static bool operator ==(BigInteger a, BigNumber b) => a == b.value;
        public static bool operator !=(BigInteger a, BigNumber b) => a != b.value;
        public static bool operator <(BigInteger a, BigNumber b) => a < b.value;
        public static bool operator <=(BigInteger a, BigNumber b) => a <= b.value;
        public static bool operator >(BigInteger a, BigNumber b) => a > b.value;
        public static bool operator >=(BigInteger a, BigNumber b) => a >= b.value;

        public static BigNumber operator +(BigNumber a, int b) { a.value += b; return a; }
        public static BigNumber operator -(BigNumber a, int b) { a.value -= b; return a; }
        public static BigNumber operator *(BigNumber a, int b) { a.value *= b; return a; }
        public static BigNumber operator /(BigNumber a, int b) { a.value /= b; return a; }
        public static bool operator ==(BigNumber a, int b) => a.value == b;
        public static bool operator !=(BigNumber a, int b) => a.value != b;
        public static bool operator <(BigNumber a, int b) => a.value < b;
        public static bool operator <=(BigNumber a, int b) => a.value <= b;
        public static bool operator >(BigNumber a, int b) => a.value > b;
        public static bool operator >=(BigNumber a, int b) => a.value >= b;
        public static bool operator ==(int a, BigNumber b) => a == b.value;
        public static bool operator !=(int a, BigNumber b) => a != b.value;
        public static bool operator <(int a, BigNumber b) => a < b.value;
        public static bool operator <=(int a, BigNumber b) => a <= b.value;
        public static bool operator >(int a, BigNumber b) => a > b.value;
        public static bool operator >=(int a, BigNumber b) => a >= b.value;

        public static implicit operator BigInteger(BigNumber a) => a.value;
        public static implicit operator BigNumber(BigInteger a) => new BigNumber() { value = a };

        public static implicit operator int(BigNumber a) => (int)a.value;
        public static implicit operator BigNumber(int a) => new BigNumber() { value = a };

        public override string ToString() => this.value.ToString();

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
