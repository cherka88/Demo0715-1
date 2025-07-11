using Entity.Data;
using Entity.Models;
using Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly DemoDbContext _context;

        public OrderService(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustOrdersOrdersResult>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return await _context.Procedures.CustOrdersOrdersAsync(customerId);
        }

        public async Task<List<CustOrdersDetailResult>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _context.Procedures.CustOrdersDetailAsync(orderId);
        }
    }
}