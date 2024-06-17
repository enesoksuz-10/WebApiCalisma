using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North_Model.Concreate.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
    }
}
