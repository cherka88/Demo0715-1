using Microsoft.AspNetCore.Mvc;

using Service.Interface;

using Website.Models.Customer;

using Microsoft.AspNetCore.Authorization;

namespace Website.Controllers;
[Authorize]
public class CustomerController : Controller
{
    private readonly ICustomerService _customService;
    public CustomerController(ICustomerService customService)
    {
        _customService = customService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _customService.GetListAsync();
        var model = new List<CustomerViewModel>();
        if (data != null)
        {
            foreach (var item in data)
            {
                model.Add(new CustomerViewModel
                {
                    CustomerId = item.CustomerId,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName,
                    Country = item.Country,
                    Phone = item.Phone,
                });
            }
        }
        
        return View(model);
    }
}
