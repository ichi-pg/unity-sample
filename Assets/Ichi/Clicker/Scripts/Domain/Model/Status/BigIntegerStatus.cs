using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public class BigIntegerStatus : Status<BigInteger>, IComparable
    {
        public BigIntegerStatus(ICalculator<BigInteger> calculator) : base(calculator) {
        }

        public override string ToString() => this.Value.ToString();
        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (obj is BigIntegerStatus) {
                var i = (BigIntegerStatus)obj;
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
            if (obj is BigIntegerStatus) {
                var i = (BigIntegerStatus)obj;
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
        public static BigInteger operator +(BigIntegerStatus a, BigIntegerStatus b) => a.Value + b.Value;
        public static BigInteger operator -(BigIntegerStatus a, BigIntegerStatus b) => a.Value - b.Value;
        public static BigInteger operator *(BigIntegerStatus a, BigIntegerStatus b) => a.Value * b.Value;
        public static BigInteger operator /(BigIntegerStatus a, BigIntegerStatus b) => a.Value / b.Value;

        //演算(BigInteger)
        public static BigInteger operator +(BigIntegerStatus a, BigInteger b) => a.Value + b;
        public static BigInteger operator -(BigIntegerStatus a, BigInteger b) => a.Value - b;
        public static BigInteger operator *(BigIntegerStatus a, BigInteger b) => a.Value * b;
        public static BigInteger operator /(BigIntegerStatus a, BigInteger b) => a.Value / b;
        public static BigInteger operator +(BigInteger a, BigIntegerStatus b) => a + b.Value;
        public static BigInteger operator -(BigInteger a, BigIntegerStatus b) => a - b.Value;
        public static BigInteger operator *(BigInteger a, BigIntegerStatus b) => a * b.Value;
        public static BigInteger operator /(BigInteger a, BigIntegerStatus b) => a / b.Value;

        //演算(int)
        public static BigInteger operator +(BigIntegerStatus a, int b) => a.Value + b;
        public static BigInteger operator -(BigIntegerStatus a, int b) => a.Value - b;
        public static BigInteger operator *(BigIntegerStatus a, int b) => a.Value * b;
        public static BigInteger operator /(BigIntegerStatus a, int b) => a.Value / b;
        public static BigInteger operator +(int a, BigIntegerStatus b) => a + b.Value;
        public static BigInteger operator -(int a, BigIntegerStatus b) => a - b.Value;
        public static BigInteger operator *(int a, BigIntegerStatus b) => a * b.Value;
        public static BigInteger operator /(int a, BigIntegerStatus b) => a / b.Value;

        //比較
        public static bool operator ==(BigIntegerStatus a, BigIntegerStatus b) => a.Value == b.Value;
        public static bool operator !=(BigIntegerStatus a, BigIntegerStatus b) => a.Value != b.Value;
        public static bool operator <(BigIntegerStatus a, BigIntegerStatus b) => a.Value < b.Value;
        public static bool operator <=(BigIntegerStatus a, BigIntegerStatus b) => a.Value <= b.Value;
        public static bool operator >(BigIntegerStatus a, BigIntegerStatus b) => a.Value > b.Value;
        public static bool operator >=(BigIntegerStatus a, BigIntegerStatus b) => a.Value >= b.Value;

        //比較(BigInteger)
        public static bool operator ==(BigIntegerStatus a, BigInteger b) => a.Value == b;
        public static bool operator !=(BigIntegerStatus a, BigInteger b) => a.Value != b;
        public static bool operator <(BigIntegerStatus a, BigInteger b) => a.Value < b;
        public static bool operator <=(BigIntegerStatus a, BigInteger b) => a.Value <= b;
        public static bool operator >(BigIntegerStatus a, BigInteger b) => a.Value > b;
        public static bool operator >=(BigIntegerStatus a, BigInteger b) => a.Value >= b;
        public static bool operator ==(BigInteger a, BigIntegerStatus b) => a == b.Value;
        public static bool operator !=(BigInteger a, BigIntegerStatus b) => a != b.Value;
        public static bool operator <(BigInteger a, BigIntegerStatus b) => a < b.Value;
        public static bool operator <=(BigInteger a, BigIntegerStatus b) => a <= b.Value;
        public static bool operator >(BigInteger a, BigIntegerStatus b) => a > b.Value;
        public static bool operator >=(BigInteger a, BigIntegerStatus b) => a >= b.Value;

        //比較(int)
        public static bool operator ==(BigIntegerStatus a, int b) => a.Value == b;
        public static bool operator !=(BigIntegerStatus a, int b) => a.Value != b;
        public static bool operator <(BigIntegerStatus a, int b) => a.Value < b;
        public static bool operator <=(BigIntegerStatus a, int b) => a.Value <= b;
        public static bool operator >(BigIntegerStatus a, int b) => a.Value > b;
        public static bool operator >=(BigIntegerStatus a, int b) => a.Value >= b;
        public static bool operator ==(int a, BigIntegerStatus b) => a == b.Value;
        public static bool operator !=(int a, BigIntegerStatus b) => a != b.Value;
        public static bool operator <(int a, BigIntegerStatus b) => a < b.Value;
        public static bool operator <=(int a, BigIntegerStatus b) => a <= b.Value;
        public static bool operator >(int a, BigIntegerStatus b) => a > b.Value;
        public static bool operator >=(int a, BigIntegerStatus b) => a >= b.Value;

        //キャスト
        public static implicit operator BigInteger(BigIntegerStatus a) => a.Value;
        public static implicit operator int(BigIntegerStatus a) => (int)a.Value;
    }
}
