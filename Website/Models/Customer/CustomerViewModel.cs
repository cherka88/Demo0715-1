using System.ComponentModel.DataAnnotations;

namespace Website.Models.Customer;

public class CustomerViewModel
{
    [Display(Name = "CustomerId")]
    public string CustomerId { get; set; } = null!;

    [Display(Name = "CompanyName")]
    public string CompanyName { get; set; } = null!;

    [Display(Name = "ContactName")]
    public string? ContactName { get; set; }

    [Display(Name = "Country")]
    public string? Country { get; set; }

    [Display(Name = "Phone")]
    public string? Phone { get; set; }
}
