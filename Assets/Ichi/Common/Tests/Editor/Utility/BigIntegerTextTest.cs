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
            Assert.AreEqual("-1000", Texts.ToString(-1000));
            Assert.AreEqual("-1", Texts.ToString(-1));
            Assert.AreEqual("0", Texts.ToString(0));
            Assert.AreEqual("1", Texts.ToString(1));
            Assert.AreEqual("12", Texts.ToString(12));
            Assert.AreEqual("123", Texts.ToString(123));
            Assert.AreEqual("999", Texts.ToString(999));
            Assert.AreEqual("1a", Texts.ToString(1000));
            Assert.AreEqual("1.2a", Texts.ToString(1200));
            Assert.AreEqual("1.23a", Texts.ToString(1230));
            Assert.AreEqual("1.234a", Texts.ToString(1234));
            Assert.AreEqual("12.345a", Texts.ToString(12345));
            Assert.AreEqual("123.456a", Texts.ToString(123456));
            Assert.AreEqual("120.056a", Texts.ToString(120056));
            Assert.AreEqual("103.406a", Texts.ToString(103406));
            Assert.AreEqual("999.999a", Texts.ToString(999999));
            Assert.AreEqual("1b", Texts.ToString(1000000));
            Assert.AreEqual("1.234b", Texts.ToString(1234567));
            Assert.AreEqual("2.147c", Texts.ToString(int.MaxValue));
            Assert.AreEqual("18.446f", Texts.ToString(ulong.MaxValue));
            Assert.AreEqual("340.282l", Texts.ToString(BigInteger.Pow(ulong.MaxValue, 2)));
            Assert.AreEqual("6.277s", Texts.ToString(BigInteger.Pow(ulong.MaxValue, 3)));
            Assert.AreEqual("3.908rx", Texts.ToString(BigInteger.Pow(ulong.MaxValue, 100)));
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
