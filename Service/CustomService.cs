using Entity.Data;

using Microsoft.EntityFrameworkCore;

using Service.Model;

namespace Service
{
    public class CustomService
    {
        private readonly DemoDbContext _context;

        public CustomService(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CustomDto>> GetListAsync()
        {
            var customers = await _context.Customers
                .Select(c => new CustomDto
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
