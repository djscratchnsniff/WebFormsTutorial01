using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebFormsEmpty
{
    /// <summary>
    /// Summary description for Cylinders
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Cylinders : System.Web.Services.WebService
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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string Cylinder_getCylinderSize()
        {
            Cylinders cyl = new Cylinders();
            DataSet ds = cyl.ExecuteProcedureReturnDataSet("getCylinderSize", null);
            DataTable dt = ds.Tables[0];
            string size = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                size = $"Cylinder size is {row["cylSizeID"].ToString()} " + size;
            }
            return size;
        }
    }
}
