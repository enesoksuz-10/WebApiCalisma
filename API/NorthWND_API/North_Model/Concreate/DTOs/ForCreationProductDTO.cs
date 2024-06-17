using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North_Model.Concreate.DTOs
{
    public class ForCreationProductDTO
    {
        public string ProductName{ get; set; }
        public int SupplierID{ get; set; }
        public int CategoryID{ get; set; }
        public decimal UnitPrice{ get; set; }
        public Int16? UnitsInStock{ get; set; }
    }
}
