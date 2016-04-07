using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BF.Unity.Extension;
using BF.Unity.Helper;
using BF.Core.Log;
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
            LogProvider.Debug.Write("debug log");

            LogProvider.Error.Write("Error log");

            LogProvider.Info.Write("Info log");

            LogProvider.Warn.Write("Warn log");

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

        [TestMethod]
        public void TestXmlInsert()
        {

            XmlHelper.Insert(@"D:\Private\App.config", "TestNode", "Test Text", "configuration");
            //XmlHelper.UpdateText(@"D:\Private\App.config", "node test", "configuration/TestNode");
            //XmlHelper.Delete(@"D:\Private\App.config", "configuration/TestNode");
            XmlHelper.GetElementValues(@"D:\Private\App.config", "configuration/TestNode");
        }

        [TestMethod]
        public void Test_Object_To_XML()
        {
            var app = new AppTest() { Path = "TEST 1" };
            var xmlStrig = app.ToXml();
        }

        [TestMethod]
        public void Test_XML_To_Object()
        {
            var app = new AppTest() { Path = "TEST 1" };
            var xmlStrig = app.ToXml();

            var app2 = xmlStrig.ToObject<AppTest>();

        }
    }
    public class AppTest
    {
        public string Path { set; get; }
    }
}
