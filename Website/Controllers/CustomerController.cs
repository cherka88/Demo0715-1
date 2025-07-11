using Microsoft.AspNetCore.Authorization;

using Service.Interface;

using Website.Models.Customer;

namespace Website.Controllers;
[Authorize]
public class CustomerController : Controller
{
    private readonly ICustomerService _customService;
    public CustomerController(ICustomerService customService)
    {
        _customService = customService;
    }

    [HttpGet]
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
