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
        public BigInteger Value { get; private set; }

        public void PreSave() {
            this.s = this.Value.ToString();
        }

        public void PostLoad() {
            this.Value = BigInteger.Parse(this.s);
        }

        public BigNumber() {
            this.Value = 0;
        }

        public BigNumber(BigNumber i) {
            this.Value = i.Value;
        }

        public BigNumber(BigInteger i) {
            this.Value = i;
        }

        public BigNumber(int i) {
            this.Value = i;
        }

        public static BigNumber operator +(BigNumber a, BigNumber b) { a.Value += b.Value; return a; }
        public static BigNumber operator -(BigNumber a, BigNumber b) { a.Value -= b.Value; return a; }
        public static BigNumber operator *(BigNumber a, BigNumber b) { a.Value *= b.Value; return a; }
        public static BigNumber operator /(BigNumber a, BigNumber b) { a.Value /= b.Value; return a; }
        public static bool operator ==(BigNumber a, BigNumber b) => a.Value == b.Value;
        public static bool operator !=(BigNumber a, BigNumber b) => a.Value != b.Value;
        public static bool operator <(BigNumber a, BigNumber b) => a.Value < b.Value;
        public static bool operator <=(BigNumber a, BigNumber b) => a.Value <= b.Value;
        public static bool operator >(BigNumber a, BigNumber b) => a.Value > b.Value;
        public static bool operator >=(BigNumber a, BigNumber b) => a.Value >= b.Value;

        public static BigNumber operator +(BigNumber a, BigInteger b) { a.Value += b; return a; }
        public static BigNumber operator -(BigNumber a, BigInteger b) { a.Value -= b; return a; }
        public static BigNumber operator *(BigNumber a, BigInteger b) { a.Value *= b; return a; }
        public static BigNumber operator /(BigNumber a, BigInteger b) { a.Value /= b; return a; }
        public static bool operator ==(BigNumber a, BigInteger b) => a.Value == b;
        public static bool operator !=(BigNumber a, BigInteger b) => a.Value != b;
        public static bool operator <(BigNumber a, BigInteger b) => a.Value < b;
        public static bool operator <=(BigNumber a, BigInteger b) => a.Value <= b;
        public static bool operator >(BigNumber a, BigInteger b) => a.Value > b;
        public static bool operator >=(BigNumber a, BigInteger b) => a.Value >= b;

        public static BigNumber operator +(BigNumber a, int b) { a.Value += b; return a; }
        public static BigNumber operator -(BigNumber a, int b) { a.Value -= b; return a; }
        public static BigNumber operator *(BigNumber a, int b) { a.Value *= b; return a; }
        public static BigNumber operator /(BigNumber a, int b) { a.Value /= b; return a; }
        public static bool operator ==(BigNumber a, int b) => a.Value == b;
        public static bool operator !=(BigNumber a, int b) => a.Value != b;
        public static bool operator <(BigNumber a, int b) => a.Value < b;
        public static bool operator <=(BigNumber a, int b) => a.Value <= b;
        public static bool operator >(BigNumber a, int b) => a.Value > b;
        public static bool operator >=(BigNumber a, int b) => a.Value >= b;

        public static implicit operator BigInteger(BigNumber a) => a.Value;
        public static implicit operator BigNumber(BigInteger a) => new BigNumber(a);

        public static implicit operator int(BigNumber a) => (int)a.Value;
        public static implicit operator BigNumber(int a) => new BigNumber(a);

        public override string ToString() => this.s;

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
