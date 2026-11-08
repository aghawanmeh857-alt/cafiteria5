namespace UniversityCafeteria5.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }
}
