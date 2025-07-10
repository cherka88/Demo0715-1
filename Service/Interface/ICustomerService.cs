using Service.Model;

namespace Service.Interface;
public interface ICustomerService
{
    /// <summary>
    /// 取得 Custom 清單
    /// </summary>
    /// <returns></returns>
    Task<IList<CustomerDto>> GetListAsync();
}
