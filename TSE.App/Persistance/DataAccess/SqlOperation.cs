using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TSE.App.Persistance.AccessData
{
    public class SqlOperation
    {
        public List<SqlParameter> Parameters { get; private set; }
        public string ProcedureName { get; set; }

        public SqlOperation(string procedureName)
        {
            Parameters = new List<SqlParameter>();
            ProcedureName = procedureName;
        }

        public void addParameter(string paramName, string value) {
            register(paramName, SqlDbType.VarChar, value);
        }

        public void addParameter(string paramName, int value)
        {
            register(paramName, SqlDbType.Int, value);
        }

        public void addParameter(string paramName, DateTime value)
        {
            register(paramName,SqlDbType.DateTime,value);
        }

        public void addParameter(string paramName, bool value)
        {
            register(paramName, SqlDbType.Bit, value);
        }

        private void register(string paramName, SqlDbType type, object value)
        {
            var param = new SqlParameter("@P_" + paramName, type)
            {
                Value = value
            };
            Parameters.Add(param);
        }
    }
}