using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Data;

namespace Test.DapperTest
{
    public class TestModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }

    [TestClass]
    public class UnitTest1
    {

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection("");
            connection.Open();
            return connection;
        }

        [TestMethod]
        public void Add()
        {
            
        }

        [TestMethod]
        public void Query()
        {
            using (IDbConnection conn = OpenConnection())
            {

            }
                
        }

        [TestMethod]
        public void Update()
        {

        }

        [TestMethod]
        public void Delete()
        {

        }

    }
}
