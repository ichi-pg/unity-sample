using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Common
{
    [Serializable]
    public class BigNumber
    {
        public string s;
        private BigInteger i;
        public BigInteger Integer {
            get {
                if (this.i == 0 && this.s != "") {
                    this.i = BigInteger.Parse(this.s);
                }
                return this.i;
            }
            private set {
                this.i = value;
                this.s = value.ToString();
            }
        }

        public BigNumber() {
            this.s = "";
            this.i = 0;
        }

        public BigNumber(BigNumber i) {
            this.s = i.s;
            this.i = i.Integer;
        }

        public BigNumber(BigInteger i) {
            this.s = i.ToString();
            this.i = i;
        }

        public BigNumber(int i) {
            this.s = i.ToString();
            this.i = i;
        }

        public static BigNumber operator +(BigNumber a, BigNumber b) { a.Integer += b.Integer; return a; }
        public static BigNumber operator -(BigNumber a, BigNumber b) { a.Integer -= b.Integer; return a; }
        public static BigNumber operator *(BigNumber a, BigNumber b) { a.Integer *= b.Integer; return a; }
        public static BigNumber operator /(BigNumber a, BigNumber b) { a.Integer /= b.Integer; return a; }
        public static bool operator ==(BigNumber a, BigNumber b) => a.Integer == b.Integer;
        public static bool operator !=(BigNumber a, BigNumber b) => a.Integer != b.Integer;
        public static bool operator <(BigNumber a, BigNumber b) => a.Integer < b.Integer;
        public static bool operator <=(BigNumber a, BigNumber b) => a.Integer <= b.Integer;
        public static bool operator >(BigNumber a, BigNumber b) => a.Integer > b.Integer;
        public static bool operator >=(BigNumber a, BigNumber b) => a.Integer >= b.Integer;

        public static BigNumber operator +(BigNumber a, BigInteger b) { a.Integer += b; return a; }
        public static BigNumber operator -(BigNumber a, BigInteger b) { a.Integer -= b; return a; }
        public static BigNumber operator *(BigNumber a, BigInteger b) { a.Integer *= b; return a; }
        public static BigNumber operator /(BigNumber a, BigInteger b) { a.Integer /= b; return a; }
        public static bool operator ==(BigNumber a, BigInteger b) => a.Integer == b;
        public static bool operator !=(BigNumber a, BigInteger b) => a.Integer != b;
        public static bool operator <(BigNumber a, BigInteger b) => a.Integer < b;
        public static bool operator <=(BigNumber a, BigInteger b) => a.Integer <= b;
        public static bool operator >(BigNumber a, BigInteger b) => a.Integer > b;
        public static bool operator >=(BigNumber a, BigInteger b) => a.Integer >= b;

        public static BigNumber operator +(BigNumber a, int b) { a.Integer += b; return a; }
        public static BigNumber operator -(BigNumber a, int b) { a.Integer -= b; return a; }
        public static BigNumber operator *(BigNumber a, int b) { a.Integer *= b; return a; }
        public static BigNumber operator /(BigNumber a, int b) { a.Integer /= b; return a; }
        public static bool operator ==(BigNumber a, int b) => a.Integer == b;
        public static bool operator !=(BigNumber a, int b) => a.Integer != b;
        public static bool operator <(BigNumber a, int b) => a.Integer < b;
        public static bool operator <=(BigNumber a, int b) => a.Integer <= b;
        public static bool operator >(BigNumber a, int b) => a.Integer > b;
        public static bool operator >=(BigNumber a, int b) => a.Integer >= b;

        public static implicit operator BigInteger(BigNumber a) => a.Integer;
        public static implicit operator BigNumber(BigInteger a) => new BigNumber(a);

        public static implicit operator int(BigNumber a) => (int)a.Integer;
        public static implicit operator BigNumber(int a) => new BigNumber(a);

        public override string ToString() => this.s;

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
