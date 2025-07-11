using Service.Model;

namespace Service.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// 取得目前商品清單
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetCurrentProductsAsync();
    }
}
