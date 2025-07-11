using Entity.Models;

namespace Service.Interface
{
    public interface IOrderService
    {
        /// <summary>
        /// 取得客戶訂單紀錄
        /// </summary>
        /// <param name="customerId">客戶代號</param>
        /// <returns></returns>
        Task<List<CustOrdersOrdersResult>> GetOrdersByCustomerIdAsync(string customerId);

        /// <summary>
        /// 取得客戶訂單明細
        /// </summary>
        /// <param name="orderId">訂單編號</param>
        /// <returns></returns>
        Task<List<CustOrdersDetailResult>> GetOrderDetailsByOrderIdAsync(int orderId);
    }
}