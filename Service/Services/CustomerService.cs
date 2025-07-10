using Entity.Data;

using Microsoft.EntityFrameworkCore;

using Service.Interface;
using Service.Model;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DemoDbContext _context;

        public CustomerService(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CustomerDto>> GetListAsync()
        {
            var customers = await _context.Customers
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    Country = c.Country,
                    Phone = c.Phone
                })
                .ToListAsync();

            return customers;
        }
    }
}
