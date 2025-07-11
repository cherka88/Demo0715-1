using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Website.Models.Product;

namespace Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

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
