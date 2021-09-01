using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Common
{
    [Serializable]
    public struct BigNumber : IPreSave, IPostLoad, IComparable
    {
        public string s;
        private BigInteger value;

        public void PreSave() {
            this.s = this.value.ToString();
        }

        public void PostLoad() {
            this.value = BigInteger.Parse(this.s);
        }

        public override string ToString() => this.value.ToString();
        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj is BigNumber) {
                var i = (BigNumber)obj;
                return this == i;
            }
            if (obj is BigInteger) {
                var i = (BigInteger)obj;
                return this == i;
            }
            if (obj is int) {
                var i = (int)obj;
                return this == i;
            }
            return false;
        }

        public int CompareTo(object obj) {
            if (obj == null) {
                return 0;
            }
            if (obj is BigNumber) {
                var i = (BigNumber)obj;
                return this < i ? -1 : this == i ? 0 : 1;
            }
            if (obj is BigInteger) {
                var i = (BigInteger)obj;
                return this < i ? -1 : this == i ? 0 : 1;
            }
            if (obj is int) {
                var i = (int)obj;
                return this < i ? -1 : this == i ? 0 : 1;
            }
            return 0;
        }

        //演算
        public static BigInteger operator +(BigNumber a, BigNumber b) => a.value + b.value;
        public static BigInteger operator -(BigNumber a, BigNumber b) => a.value - b.value;
        public static BigInteger operator *(BigNumber a, BigNumber b) => a.value * b.value;
        public static BigInteger operator /(BigNumber a, BigNumber b) => a.value / b.value;

        //演算(BigInteger)
        public static BigInteger operator +(BigNumber a, BigInteger b) => a.value + b;
        public static BigInteger operator -(BigNumber a, BigInteger b) => a.value - b;
        public static BigInteger operator *(BigNumber a, BigInteger b) => a.value * b;
        public static BigInteger operator /(BigNumber a, BigInteger b) => a.value / b;
        public static BigInteger operator +(BigInteger a, BigNumber b) => a + b.value;
        public static BigInteger operator -(BigInteger a, BigNumber b) => a - b.value;
        public static BigInteger operator *(BigInteger a, BigNumber b) => a * b.value;
        public static BigInteger operator /(BigInteger a, BigNumber b) => a / b.value;

        //演算(int)
        public static BigInteger operator +(BigNumber a, int b) => a.value + b;
        public static BigInteger operator -(BigNumber a, int b) => a.value - b;
        public static BigInteger operator *(BigNumber a, int b) => a.value * b;
        public static BigInteger operator /(BigNumber a, int b) => a.value / b;
        public static BigInteger operator +(int a, BigNumber b) => a + b.value;
        public static BigInteger operator -(int a, BigNumber b) => a - b.value;
        public static BigInteger operator *(int a, BigNumber b) => a * b.value;
        public static BigInteger operator /(int a, BigNumber b) => a / b.value;

        //比較
        public static bool operator ==(BigNumber a, BigNumber b) => a.value == b.value;
        public static bool operator !=(BigNumber a, BigNumber b) => a.value != b.value;
        public static bool operator <(BigNumber a, BigNumber b) => a.value < b.value;
        public static bool operator <=(BigNumber a, BigNumber b) => a.value <= b.value;
        public static bool operator >(BigNumber a, BigNumber b) => a.value > b.value;
        public static bool operator >=(BigNumber a, BigNumber b) => a.value >= b.value;

        //比較(BigInteger)
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

        //比較(int)
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

        //キャスト
        public static implicit operator BigInteger(BigNumber a) => a.value;
        public static implicit operator BigNumber(BigInteger a) => new BigNumber() { value = a };
        public static implicit operator int(BigNumber a) => (int)a.value;
        public static implicit operator BigNumber(int a) => new BigNumber() { value = a };
    }
}
