using System.ComponentModel.DataAnnotations;

namespace Website.Models.Product
{
    public class ProductViewModel
    {
        [Display(Name = "產品編號")]
        public int ProductId { get; set; }

        [Display(Name = "產品名稱")]
        public string ProductName { get; set; }
    }
}
