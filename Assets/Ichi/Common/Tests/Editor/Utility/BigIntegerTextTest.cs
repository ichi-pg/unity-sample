using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Ichi.Common
{
    public class BigIntegerTextTest
    {
        [Test]
        public void ToStringTest() {
            Assert.AreEqual("-1000", BigIntegerText.ToString(-1000));
            Assert.AreEqual("-1", BigIntegerText.ToString(-1));
            Assert.AreEqual("0", BigIntegerText.ToString(0));
            Assert.AreEqual("1", BigIntegerText.ToString(1));
            Assert.AreEqual("12", BigIntegerText.ToString(12));
            Assert.AreEqual("123", BigIntegerText.ToString(123));
            Assert.AreEqual("999", BigIntegerText.ToString(999));
            Assert.AreEqual("1a", BigIntegerText.ToString(1000));
            Assert.AreEqual("1.2a", BigIntegerText.ToString(1200));
            Assert.AreEqual("1.23a", BigIntegerText.ToString(1230));
            Assert.AreEqual("1.234a", BigIntegerText.ToString(1234));
            Assert.AreEqual("12.345a", BigIntegerText.ToString(12345));
            Assert.AreEqual("123.456a", BigIntegerText.ToString(123456));
            Assert.AreEqual("120.056a", BigIntegerText.ToString(120056));
            Assert.AreEqual("103.406a", BigIntegerText.ToString(103406));
            Assert.AreEqual("999.999a", BigIntegerText.ToString(999999));
            Assert.AreEqual("1b", BigIntegerText.ToString(1000000));
            Assert.AreEqual("1.234b", BigIntegerText.ToString(1234567));
            Assert.AreEqual("2.147c", BigIntegerText.ToString(int.MaxValue));
            Assert.AreEqual("18.446f", BigIntegerText.ToString(ulong.MaxValue));
            Assert.AreEqual("340.282l", BigIntegerText.ToString(BigInteger.Pow(ulong.MaxValue, 2)));
            Assert.AreEqual("6.277s", BigIntegerText.ToString(BigInteger.Pow(ulong.MaxValue, 3)));
            Assert.AreEqual("3.908rx", BigIntegerText.ToString(BigInteger.Pow(ulong.MaxValue, 100)));
            //TOOD BigIntegerの限界桁数の把握
            //TOOD Omitの限界パフォーマンスの把握
            // BigIntegerText.ToString(BigInteger.Pow(ulong.MaxValue, 123456));//これはフリーズした
            try {
                BigInteger.Pow(int.MaxValue, int.MaxValue);
            } catch (Exception e) {
                Assert.AreEqual(typeof(OverflowException), e.GetType());
            }
        }
    }
}
