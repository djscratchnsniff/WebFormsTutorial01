using System;
using System.Web.Services;
using System.Web.Script.Serialization;
using DataAccess.DataSprocs;

namespace WebServices.Cylinders
{
    /// <summary>
    /// Summary description for WS_GetCylinderSize
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_GetCylinderSize : System.Web.Services.WebService
    {

        [WebMethod]
        public string Cylinder_GetCylinderSizes()
        {
            String result = String.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            GetCylinderSize sizes = new GetCylinderSize();
            result = js.Serialize(sizes.SP_GetCylinderSizes());
            Context.Response.Clear();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Flush();
            Context.Response.Write(result);
            Context.Response.End();
            return result;
        }
    }
}
