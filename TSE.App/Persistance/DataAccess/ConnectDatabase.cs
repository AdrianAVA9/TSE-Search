using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TSE.App.Persistance.AccessData
{
    public class ConnectDatabase
    {
        private static ConnectDatabase _instance { get; set; }
        private string CONNECTION_STRING { get; set; }

        private ConnectDatabase()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["TSE-CONN_STRING"].ConnectionString;
        }

        public static ConnectDatabase GetInstance()
        {
            if (_instance == null) _instance = new ConnectDatabase();

            return _instance;
        }

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dict = new Dictionary<string, object>();
                        for (var lp = 0; lp < reader.FieldCount; lp++)
                        {
                            dict.Add(reader.GetName(lp), reader.GetValue(lp));
                        }
                        lstResult.Add(dict);
                    }
                }
            }

            return lstResult;
        }
    }
}