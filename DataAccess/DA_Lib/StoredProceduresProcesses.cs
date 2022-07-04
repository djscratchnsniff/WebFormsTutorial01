using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccess
{
    public class StoredProceduresProcesses
    {
        public DataSet ExecuteProcedureReturnDataSet(string procName, params SqlParameter[] parameters)
        {
            DataSet result = null;

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RRSConn"].ToString()))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = procName;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        result = new DataSet();
                        sda.Fill(result);
                    }
                }
            }
            return result;
        }

        public List<SqlParameter> ExecuteProcedureReturnOutputParameters(string connectionString, string procName, params SqlParameter[] parameters)
        {
            List<SqlParameter> result = new List<SqlParameter>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                    var str = command.CommandText;
                    foreach (var item in parameters)
                    {
                        result.Add(new SqlParameter(item.ParameterName, item.Value));
                    }
                }
            }
            return result;
        }
    }
}
