using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarsCipher;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var test = new CaesarsCipher.CaesarsCipher(alphabet, 3);

            string encoded = test.Encode("HELLO LEO");
            Assert.AreEqual("KHOORCOHR", encoded);
        }

        [TestMethod]
        public void TestForValuesNotInCipher()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var test = new CaesarsCipher.CaesarsCipher(alphabet, 3);

            try { test.Encode("HELLO LEO"); }
            catch (ArgumentOutOfRangeException e)
            { };
        }

    }
}
