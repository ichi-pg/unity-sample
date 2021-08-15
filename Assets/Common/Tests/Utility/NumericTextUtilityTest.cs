using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Common
{
    public class NumericTextUtilityTest
    {
        [Test]
        public void OmitTest() {
            Assert.AreEqual("-1000", NumericTextUtility.Omit(-1000));
            Assert.AreEqual("-1", NumericTextUtility.Omit(-1));
            Assert.AreEqual("0", NumericTextUtility.Omit(0));
            Assert.AreEqual("1", NumericTextUtility.Omit(1));
            Assert.AreEqual("12", NumericTextUtility.Omit(12));
            Assert.AreEqual("123", NumericTextUtility.Omit(123));
            Assert.AreEqual("999", NumericTextUtility.Omit(999));
            Assert.AreEqual("1a", NumericTextUtility.Omit(1000));
            Assert.AreEqual("1.2a", NumericTextUtility.Omit(1200));
            Assert.AreEqual("1.23a", NumericTextUtility.Omit(1230));
            Assert.AreEqual("1.234a", NumericTextUtility.Omit(1234));
            Assert.AreEqual("12.345a", NumericTextUtility.Omit(12345));
            Assert.AreEqual("123.456a", NumericTextUtility.Omit(123456));
            Assert.AreEqual("120.056a", NumericTextUtility.Omit(120056));
            Assert.AreEqual("103.406a", NumericTextUtility.Omit(103406));
            Assert.AreEqual("999.999a", NumericTextUtility.Omit(999999));
            Assert.AreEqual("1b", NumericTextUtility.Omit(1000000));
            Assert.AreEqual("1.234b", NumericTextUtility.Omit(1234567));
            Assert.AreEqual("2.147c", NumericTextUtility.Omit(int.MaxValue));
            Assert.AreEqual("18.446f", NumericTextUtility.Omit(ulong.MaxValue));
            Assert.AreEqual("340.282l", NumericTextUtility.Omit(System.Numerics.BigInteger.Pow(ulong.MaxValue, 2)));
            Assert.AreEqual("6.277s", NumericTextUtility.Omit(System.Numerics.BigInteger.Pow(ulong.MaxValue, 3)));
            Assert.AreEqual("3.908rx", NumericTextUtility.Omit(System.Numerics.BigInteger.Pow(ulong.MaxValue, 100)));
            //TOOD BigIntegerの限界桁数の把握
            //TOOD Omitの限界パフォーマンスの把握
            // NumericTextUtility.Omit(System.Numerics.BigInteger.Pow(ulong.MaxValue, 123456));//これはフリーズした
            try {
                System.Numerics.BigInteger.Pow(int.MaxValue, int.MaxValue);
            } catch (System.Exception e) {
                Assert.AreEqual(typeof(System.OverflowException), e.GetType());
            }
        }
    }
}
