using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using DataAccess;
using DataAccess.DataSprocs;

namespace WebServices
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
        [WebMethod]
        public string Cylinder_getCylinderItems()
        {
            String result = String.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            GetCylinderItems items = new GetCylinderItems();            

            result = js.Serialize(items.SP_GetCylinderItems());
            Context.Response.Clear();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Flush();
            Context.Response.Write(result);
            Context.Response.End();
            return result;
        }
    }
}
