using Entity.Data;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using Service.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly DemoDbContext _context;

        public SupplierService(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierDto>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers
                .Select(s => new SupplierDto
                {
                    SupplierID = s.SupplierId,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    Phone = s.Phone
                })
                .ToListAsync();
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return null;
            }
            return new SupplierDto
            {
                SupplierID = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage
            };
        }

        public async Task AddSupplierAsync(SupplierDto supplierDto)
        {
            var supplier = new Supplier
            {
                CompanyName = supplierDto.CompanyName,
                ContactName = supplierDto.ContactName,
                ContactTitle = supplierDto.ContactTitle,
                Address = supplierDto.Address,
                City = supplierDto.City,
                Region = supplierDto.Region,
                PostalCode = supplierDto.PostalCode,
                Country = supplierDto.Country,
                Phone = supplierDto.Phone,
                Fax = supplierDto.Fax,
                HomePage = supplierDto.HomePage
            };
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            supplierDto.SupplierID = supplier.SupplierId; // Update DTO with generated ID
        }

        public async Task UpdateSupplierAsync(SupplierDto supplierDto)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierDto.SupplierID);
            if (supplier == null)
            {
                return; // Or throw an exception
            }

            supplier.CompanyName = supplierDto.CompanyName;
            supplier.ContactName = supplierDto.ContactName;
            supplier.ContactTitle = supplierDto.ContactTitle;
            supplier.Address = supplierDto.Address;
            supplier.City = supplierDto.City;
            supplier.Region = supplierDto.Region;
            supplier.PostalCode = supplierDto.PostalCode;
            supplier.Country = supplierDto.Country;
            supplier.Phone = supplierDto.Phone;
            supplier.Fax = supplierDto.Fax;
            supplier.HomePage = supplierDto.HomePage;

            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return false;
            }

            var hasProducts = await _context.Products.AnyAsync(p => p.SupplierId == id);
            if (hasProducts)
            {
                // 商品中有廠商的資料，無法刪除
                return false;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}