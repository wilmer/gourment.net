using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCM.Cocina.DataAccess.Lib
{
    public class OperationHelper
    {
        static string SQLDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public static Database GetGBLRendicionesDataBase()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault();
            return db;
        }

        public static Database GetGBLDataBase()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            var db = factory.Create("PCE");
            return db;
        }

        public static Database GetDatabaseSecurity()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            var db = factory.Create("PCM");
            return db;
        }

        public static String GenerateAccessorString(DbCommand cmd)
        {
            List<string> components = new List<string> { "EXEC" };
            DbParameter[] s = new DbParameter[cmd.Parameters.Count];
            cmd.Parameters.CopyTo(s, 0);
            IList<String> paramList = new List<String>();
            s.ToList().ForEach(m =>
            {
                paramList.Add(m.ParameterName + "='" +
                    ((m.DbType == DbType.DateTime || m.DbType == DbType.Date) ? ((DateTime)m.Value).ToString(SQLDateTimeFormat) : m.Value) + "'");
            });
            components.Add(cmd.CommandText);
            components.Add(String.Join(",", paramList));
            return String.Join(" ", components);

        }

        public static String GenerateEscalarString(string cmd)
        {
            return cmd.Replace("''", "'");
        }

        public static DbConnection GetConnection()
        {
            return GetGBLDataBase().CreateConnection();
        }

        public static DbConnection GetConnectionDBSecurity()
        {
            return GetDatabaseSecurity().CreateConnection();
        }

        public static DbTransaction GetTransaction()
        {
            var conn = GetConnection();
            conn.Open();
            return conn.BeginTransaction();

        }
        public static DbTransaction GetTransactionDBSecurity()
        {
            var conn = GetConnectionDBSecurity();
            conn.Open();
            return conn.BeginTransaction();
        }

        //public T ExecuteOnOpennedConnection<T>(Func<T> codeToExecute, Object obj)
        //{
        //    var db=GetDatabase();
        //    try
        //    {
        //        var con = db.CreateConnection();
        //        var trans = con.BeginTransaction();
        //        Object[] prm = { trans, con };
        //        return codeToExecute.Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //        return default(T);
        //    }
        //    }
        //}
        //static List<Object> passingLambda(Func<T> lambda) {
        //}
    }
}
