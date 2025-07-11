using Microsoft.AspNetCore.Authorization;

using Service.Interface;

using Website.Models.Product;

namespace Website.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productsDto = await _productService.GetCurrentProductsAsync();
            var productsViewModel = productsDto.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName
            }).ToList();

            return View(productsViewModel);
        }
    }
}
