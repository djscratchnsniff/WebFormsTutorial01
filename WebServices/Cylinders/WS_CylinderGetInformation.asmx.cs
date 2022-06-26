using System;
using System.Web.Services;
using System.Web.Script.Serialization;
using DataAccess.DataSprocs;
using DataAccess.DataObjects;

namespace WebServices.Cylinders
{
    /// <summary>
    /// Summary description for WS_CylinderGetInformation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_CylinderGetInformation : System.Web.Services.WebService
    {
        [WebMethod]
        public string Cylinder_GetInformationByBarcodeOrSerial(Cylinder cylinder)
        {
            String result = String.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cylinder_GetInformation cylinders = new Cylinder_GetInformation();
            result = js.Serialize(cylinders.SP_Cylinder_GetInformation(cylinder));
            Context.Response.Clear();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Flush();
            Context.Response.Write(result);
            Context.Response.End();
            return result;
        }
    }
}
