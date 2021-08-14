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
        public void OmitTest()
        {
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
            Assert.AreEqual("999.999a", NumericTextUtility.Omit(999999));
            Assert.AreEqual("1b", NumericTextUtility.Omit(1000000));
            Assert.AreEqual("1.235b", NumericTextUtility.Omit(1234567));
            //TODO そもそも単純な整数型では持ちきれない桁数
        }

        //TODO Consoleで自動実行されない
    }
}
