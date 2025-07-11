using System.ComponentModel.DataAnnotations;

namespace Website.Models.Supplier
{
    public class SupplierViewModel
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
}