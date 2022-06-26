using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.DataObjects;
using System.Data.SqlClient;

namespace DataAccess.DataSprocs
{
    public class Cylinder_GetInformation
    {
        public List<Cylinder> SP_Cylinder_GetInformation(Cylinder inCylinder)
        {
            StoredProceduresProcesses sp = new StoredProceduresProcesses(); 
            SqlParameter[] parameter = {
                new SqlParameter("@inBarcode",inCylinder.Barcode)
                , new SqlParameter("@InSerial", inCylinder.Serial)
            };
            List<Cylinder> cylinders = new List<Cylinder>();

            DataSet ds = sp.ExecuteProcedureReturnDataSet("Cylinder_GetInformation", parameter);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Cylinder cylinder = new Cylinder();
                cylinder.Barcode = row["Barcode"].ToString();
                cylinder.Serial = row["Serial"].ToString();
                cylinder.CylSizeID = row["cylSizeID"].ToString();
                cylinder.RecertDate = Convert.ToDateTime(row["recertDate"]);
                cylinder.RecertDateStr = row["recertDate"].ToString();
                cylinder.Tare = Convert.ToInt32(row["tare"]);
                cylinder.RetLocID = Convert.ToInt32(row["retLocId"]);
                cylinders.Add(cylinder);
            }
            return cylinders;
        }
    }
}
