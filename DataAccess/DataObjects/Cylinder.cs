using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataObjects
{
    public class Cylinder
    {
        public string Barcode { get; set; }
        public string Serial { get; set; }
        public string CylSizeID { get; set; }
        public DateTime RecertDate { get; set; }
        public string RecertDateStr { get; set; }
        public string CustOwned { get; set; }
        public int Tare { get; set; }
        public int RetLocID { get; set; }

        /* 
         cylSizeID	recertDate	CustOwned	tare	retLocID	returnLocAddr	statusName	OrderID	custID	billingAddr	ordStatus	cylStatus	seqID	ValidRecert	
         */
    }
}
