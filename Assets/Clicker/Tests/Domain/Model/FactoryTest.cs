using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Clicker
{
    public class FactoryTest
    {
        [Test]
        public void PowerTest() {
            Assert.AreEqual("1078", new Factory(7, 22).Power.ToString());
            Assert.AreEqual("1.078a", Common.NumericTextUtility.Omit(new Factory(7, 22).Power));
            Assert.AreEqual("1127", new Factory(7, 23).Power.ToString());
            Assert.AreEqual("1.127a", Common.NumericTextUtility.Omit(new Factory(7, 23).Power));
            Assert.AreEqual("181.548a", Common.NumericTextUtility.Omit(new Factory(123, 12).Power));
            Assert.AreEqual("1.86b", Common.NumericTextUtility.Omit(new Factory(123, 123).Power));
            Assert.AreEqual("18.669b", Common.NumericTextUtility.Omit(new Factory(123, 1234).Power));
            Assert.AreEqual("186.767b", Common.NumericTextUtility.Omit(new Factory(123, 12345).Power));
            Assert.AreEqual("17.712a", Common.NumericTextUtility.Omit(new Factory(12, 123).Power));
            Assert.AreEqual("1.86b", Common.NumericTextUtility.Omit(new Factory(123, 123).Power));
            Assert.AreEqual("187.298b", Common.NumericTextUtility.Omit(new Factory(1234, 123).Power));
            Assert.AreEqual("18.745c", Common.NumericTextUtility.Omit(new Factory(12345, 123).Power));
            Assert.AreEqual("9.903i", Common.NumericTextUtility.Omit(new Factory(int.MaxValue, int.MaxValue).Power));
        }
    }
}
