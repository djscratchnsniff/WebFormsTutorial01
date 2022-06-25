using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace DataAccess.DataSprocs
{
    public class GetCylinderItems
    {
        public List<CylinderItems> SP_GetCylinderItems()
        {
            StoredProceduresProcesses sp = new StoredProceduresProcesses();
            List<CylinderItems> items = new List<CylinderItems>();

            DataSet ds = sp.ExecuteProcedureReturnDataSet("getCylinderItems", null);
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
            return items;
        }

    }

}
