using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WebFormsEmpty
{
    /// <summary>
    /// Summary description for GetCylinderItems
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CylinderItems
    {
        public string SupItem { get; set; }
        public string ItemMisId { get; set; }
    }
    public class GetCylinderItems : System.Web.Services.WebService
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
        public string Cylinder_getCylinderItems()
        {
            String result = String.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<CylinderItems> items = new List<CylinderItems>();

            GetCylinderItems cylinderItems = new GetCylinderItems();
            DataSet ds = cylinderItems.ExecuteProcedureReturnDataSet("getCylinderItems", null);
            DataTable dt = ds.Tables[0];
            string supItem = string.Empty;
            string itemMisId = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                CylinderItems item = new CylinderItems();
                item.SupItem = $"Cylinder item is {row["supItem"].ToString()} ";
                item.ItemMisId = $"ItemMisId is {row["itemMisId"].ToString()}";
                items.Add(item);
            }

            result = js.Serialize(items);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Flush();
            Context.Response.Write(result);
            Context.Response.End();
            return result;
        }
    }
}
