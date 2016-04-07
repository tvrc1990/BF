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
            var config = ConfigProvider<AppTest>.Xml;
            var result = config.Get();
            if (result == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Test_Config_Update()
        {
            var config = ConfigProvider<AppTest>.Xml;
            var result = config.Update(new AppTest() { Path="2"});
            if (result == null)
            {
                Assert.Fail();
            }
        }


    }
}
