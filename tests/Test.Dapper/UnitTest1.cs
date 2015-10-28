using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Dapper.Extension;

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
                string sql = "SELECT * FROM TB";
                var result = conn.Query<TestModel>(sql, new { Id = 1 });
            }
                
        }

        [TestMethod]
        public void Update()
        {

        }

        [TestMethod]
        public void Delete()
        {
            string conn=@"data source=S1DSQL04\S7EDIDB01;database=MKTPLS;user id=EDIDbo;password=4ediuse0nly;Timeout=30;connection lifetime=300; min pool size=2; max pool size=50";
            new DbBase(conn).Delete<TestModel>();
        }

    }
}
