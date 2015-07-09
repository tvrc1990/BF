using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BF.Unity.Extension;
using BF.Log;

namespace Test.Extension
{
    [TestClass]
    public class UnityTest
    {
        [TestMethod]
        public void TestCryptoHelper()
        {
            const string strObj = "Test Content";
            var descDecrypt = strObj.DESCEncrypt();
            var descResult = descDecrypt.DESCDecrypt();

            var md5Result = strObj.MD5Encrypt();
            Assert.AreEqual(31, md5Result.Length);
            Assert.AreEqual(strObj, descResult);
        }

        [TestMethod]
        public void TestStringExtension()
        {
            const string strObj = "Test 1分";
            const string stringObj = "1,2,3,4,";
            const string stringHtml = "<p>test</p>";

            Assert.AreEqual(1, stringObj.ToIntArray(',')[0]);
            Assert.AreEqual("1", stringObj.ToStrArray(',')[0]);
            Assert.AreEqual("Test", strObj.Left(4));
            Assert.AreEqual(8, strObj.GetSize());

            var temp = stringHtml.HtmlEncode();
            Assert.AreEqual(stringHtml, temp.HtmlDecode());


        }

        [TestMethod]
        public void TestLog()
        {
            var log = LogFactory.ErrorInstance();
            var log2 = LogFactory.ErrorInstance();
            Assert.AreNotEqual(null, log);
        }

        [TestMethod]
        public void TestEceptionExtension()
        {
            string content = "";
            try
            {
                string t = "123sd";
                Convert.ToInt32(t);
            }
            catch (Exception e)
            {

                content = e.ToLog();
            }
             Assert.AreNotEqual("", content);
        }
        

    }
}
