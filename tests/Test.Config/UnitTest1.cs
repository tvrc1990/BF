using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BF.Core.Config;

namespace Test.Config
{
    [TestClass]
    public class UnitTest1
    {
        public class AppTest
        {
            public string Path { set; get; }
        }

        [TestMethod]
        public void Test_Config_Get()
        {
            var result = ConfigProvider<AppTest>.Xml.Get();
            var result1 = ConfigProvider<AppTest>.Xml.Get();
            if (result == null)
            {
                Assert.Fail();
            }
        }

      


    }
}
