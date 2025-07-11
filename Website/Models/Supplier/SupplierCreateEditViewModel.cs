using System.ComponentModel.DataAnnotations;

namespace Website.Models.Supplier
{
    public class SupplierCreateEditViewModel
    {
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        [StringLength(40, ErrorMessage = "Company Name cannot exceed 40 characters.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; } = null!;

        [StringLength(30, ErrorMessage = "Contact Name cannot exceed 30 characters.")]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; } = null!;

        [StringLength(30, ErrorMessage = "Contact Title cannot exceed 30 characters.")]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; } = null!;

        [StringLength(60, ErrorMessage = "Address cannot exceed 60 characters.")]
        public string Address { get; set; } = null!;

        [StringLength(15, ErrorMessage = "City cannot exceed 15 characters.")]
        public string City { get; set; } = null!;

        [StringLength(15, ErrorMessage = "Region cannot exceed 15 characters.")]
        public string? Region { get; set; }

        [StringLength(10, ErrorMessage = "Postal Code cannot exceed 10 characters.")]
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "Country cannot exceed 15 characters.")]
        public string Country { get; set; } = null!;

        [StringLength(24, ErrorMessage = "Phone cannot exceed 24 characters.")]
        public string Phone { get; set; } = null!;

        [StringLength(24, ErrorMessage = "Fax cannot exceed 24 characters.")]
        public string? Fax { get; set; }

        [Display(Name = "Home Page")]
        public string? HomePage { get; set; }
    }
}