namespace MVC_UI.Models
{
    public class ProductGetDTO
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public string CategoryName { get; set; }

    }
}
