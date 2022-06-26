using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.DataObjects;

namespace DataAccess.DataSprocs
{
    public class GetCylinderSize
    {
        public List<CylinderSize> SP_GetCylinderSizes()
        {
            StoredProceduresProcesses sp = new StoredProceduresProcesses();
            List<CylinderSize> cylinderSizes = new List<CylinderSize>();

            DataSet ds = sp.ExecuteProcedureReturnDataSet("getCylinderSize", null);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                CylinderSize cylinderSize = new CylinderSize();
                cylinderSize.CylSizeID = $"Cylinder size is {row["cylSizeID"].ToString()} ";
                cylinderSizes.Add(cylinderSize);
            }
            return cylinderSizes;
        }
    }
}
