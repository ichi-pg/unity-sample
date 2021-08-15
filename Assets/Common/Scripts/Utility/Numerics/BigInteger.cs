using System.Collections;
using System.Collections.Generic;

namespace Common
{
    [System.Serializable]
    public class BigInteger
    {
        public string s;
        private System.Numerics.BigInteger i;
        private System.Numerics.BigInteger I {
            get {
                //TODO System.Numerics.BigIntegerがシリアライズされないので一旦
                if (this.i == 0 && this.s != "") {
                    this.i = System.Numerics.BigInteger.Parse(this.s);
                }
                return this.i;
            }
            set {
                this.i = value;
                this.s = value.ToString();
            }
        }

        public BigInteger() {
        }

        public BigInteger(BigInteger i) {
            this.s = i.s;
            this.i = i.I;
        }

        public BigInteger(System.Numerics.BigInteger i) {
            this.s = i.ToString();
            this.i = i;
        }

        public BigInteger(int i) {
            this.s = i.ToString();
            this.i = i;
        }

        public static BigInteger operator +(BigInteger a, BigInteger b) => new BigInteger(a.I + b.I);
        public static BigInteger operator -(BigInteger a, BigInteger b) => new BigInteger(a.I - b.I);
        public static BigInteger operator *(BigInteger a, BigInteger b) => new BigInteger(a.I * b.I);
        public static BigInteger operator /(BigInteger a, BigInteger b) => new BigInteger(a.I / b.I);
        public static bool operator ==(BigInteger a, BigInteger b) => a.I == b.I;
        public static bool operator !=(BigInteger a, BigInteger b) => a.I != b.I;
        public static bool operator <(BigInteger a, BigInteger b) => a.I < b.I;
        public static bool operator <=(BigInteger a, BigInteger b) => a.I <= b.I;
        public static bool operator >(BigInteger a, BigInteger b) => a.I > b.I;
        public static bool operator >=(BigInteger a, BigInteger b) => a.I >= b.I;

        public static BigInteger operator +(BigInteger a, int b) => new BigInteger(a.I + b);
        public static BigInteger operator -(BigInteger a, int b) => new BigInteger(a.I - b);
        public static BigInteger operator *(BigInteger a, int b) => new BigInteger(a.I * b);
        public static BigInteger operator /(BigInteger a, int b) => new BigInteger(a.I / b);
        public static bool operator ==(BigInteger a, int b) => a.I == b;
        public static bool operator !=(BigInteger a, int b) => a.I != b;
        public static bool operator <(BigInteger a, int b) => a.I < b;
        public static bool operator <=(BigInteger a, int b) => a.I <= b;
        public static bool operator >(BigInteger a, int b) => a.I > b;
        public static bool operator >=(BigInteger a, int b) => a.I >= b;

        public static explicit operator System.Numerics.BigInteger(BigInteger a) => a.I;

        public override string ToString() => this.s;
    }
}
