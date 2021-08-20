using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Ichi.Clicker
{
    public class FactoryTest
    {
        [Test]
        public void PowerTest() {
            var calculator = new FactoryCalculator();
            Assert.AreEqual("1078", new Factory(calculator, 7, 22).Power.ToString());
            Assert.AreEqual("1.078a", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 7, 22).Power));
            Assert.AreEqual("1127", new Factory(calculator, 7, 23).Power.ToString());
            Assert.AreEqual("1.127a", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 7, 23).Power));
            Assert.AreEqual("181.548a", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 123, 12).Power));
            Assert.AreEqual("1.86b", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 123, 123).Power));
            Assert.AreEqual("18.669b", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 123, 1234).Power));
            Assert.AreEqual("186.767b", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 123, 12345).Power));
            Assert.AreEqual("17.712a", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 12, 123).Power));
            Assert.AreEqual("1.86b", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 123, 123).Power));
            Assert.AreEqual("187.298b", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 1234, 123).Power));
            Assert.AreEqual("18.745c", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, 12345, 123).Power));
            Assert.AreEqual("9.903i", Ichi.Common.BigIntegerText.ToString(new Factory(calculator, int.MaxValue, int.MaxValue).Power));
        }
    }
}
