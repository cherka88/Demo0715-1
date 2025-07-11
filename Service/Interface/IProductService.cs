using Service.Model;

namespace Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetCurrentProductsAsync();
    }
}
