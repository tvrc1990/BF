using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BF.DB.Core;
namespace Dapper.Extension
{
    public class DapperHelper<T> : IDbCore<T> where T : class, new()
    {
        DbBase dbBase = null;
        SqlQuery sqlQuery = null;
        public DapperHelper()
        {
            dbBase = new DbBase("");
        }
        public object Add(T t)
        {
            return dbBase.Insert<T>(t);
        }

        public bool Change(T t)
        {
            return dbBase.Update<T>(t);
        }

        public bool Delete(T t)
        {
            var sql = SqlQuery<T>.Builder(dbBase);
            sql.SqlBuilder.Append("WHERE Id=@Id");
            sql.TopNumber = 1;
            return dbBase.Delete<T>(sql);
        }

        public IEnumerable<T> Query(object command = null, object param = null)
        {

            var db = dbBase.DbConnecttion;
            var sql = SqlQuery<T>.Builder(dbBase);
            if (command == null)
            {
                return db.Query<T>(sql.QuerySql, sql.Param);
            }
            else
            {
                return db.Query<T>(command.ToString(), param);
            }

        }

        public object Execute(object command, object param = null)
        {
            var db = dbBase.DbConnecttion;
            var sql = SqlQuery<T>.Builder(dbBase);
            if (command == null)
            {
                return db.ExecuteScalar(sql.QuerySql, sql.Param);
            }
            else
            {
                return db.ExecuteScalar(command.ToString(), param);
            }
        }
    }
}
