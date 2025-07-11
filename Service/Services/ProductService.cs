using Entity.Data;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using Service.Model;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly DemoDbContext _context;

        public ProductService(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetCurrentProductsAsync()
        {
            // 撈 View 表: 當前產品列表
            return await _context.CurrentProductLists
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName
                })
                .ToListAsync();
        }
    }
}
