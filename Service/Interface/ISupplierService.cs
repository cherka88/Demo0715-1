using Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISupplierService
    {
        /// <summary>
        /// 取得廠商列表
        /// </summary>
        /// <returns></returns>
        Task<List<SupplierDto>> GetAllSuppliersAsync();

        /// <summary>
        /// 取得廠商資訊
        /// </summary>
        /// <param name="id">廠商代號</param>
        /// <returns></returns>
        Task<SupplierDto> GetSupplierByIdAsync(int id);

        /// <summary>
        /// 新增廠商
        /// </summary>
        /// <param name="supplierDto"></param>
        /// <returns></returns>
        Task AddSupplierAsync(SupplierDto supplierDto);

        /// <summary>
        /// 更新廠商資訊
        /// </summary>
        /// <param name="supplierDto"></param>
        /// <returns></returns>
        Task UpdateSupplierAsync(SupplierDto supplierDto);

        /// <summary>
        /// 刪除廠商
        /// </summary>
        /// <param name="id">廠商代號</param>
        /// <returns></returns>
        Task<bool> DeleteSupplierAsync(int id);
    }
}