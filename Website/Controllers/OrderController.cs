using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest("Customer ID is required.");
            }

            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
            var viewModel = new OrderViewModel
            {
                CustomerId = customerId,
                Orders = orders
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int orderId)
        {
            var orderDetails = await _orderService.GetOrderDetailsByOrderIdAsync(orderId);
            var viewModel = new OrderViewModel
            {
                OrderDetails = orderDetails
            };
            return PartialView("_OrderDetailsPartial", viewModel);
        }
    }
}