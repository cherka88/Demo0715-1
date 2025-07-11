using Microsoft.AspNetCore.Authorization;

using Service.Interface;
using Service.Model;

using Website.Models.Supplier;

namespace Website.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            var viewModel = suppliers.Select(s => new SupplierViewModel
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                Phone = s.Phone
            }).ToList();
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var supplierDto = new SupplierDto
                {
                    CompanyName = viewModel.CompanyName,
                    ContactName = viewModel.ContactName,
                    ContactTitle = viewModel.ContactTitle,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    Region = viewModel.Region,
                    PostalCode = viewModel.PostalCode,
                    Country = viewModel.Country,
                    Phone = viewModel.Phone,
                    Fax = viewModel.Fax,
                    HomePage = viewModel.HomePage
                };
                await _supplierService.AddSupplierAsync(supplierDto);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplierDto = await _supplierService.GetSupplierByIdAsync(id);
            if (supplierDto == null)
            {
                return NotFound();
            }

            var viewModel = new SupplierCreateEditViewModel
            {
                SupplierID = supplierDto.SupplierID,
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
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var supplierDto = await _supplierService.GetSupplierByIdAsync(id);
            if (supplierDto == null)
            {
                return NotFound();
            }

            var viewModel = new SupplierCreateEditViewModel
            {
                SupplierID = supplierDto.SupplierID,
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
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SupplierCreateEditViewModel viewModel)
        {
            if (id != viewModel.SupplierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var supplierDto = new SupplierDto
                {
                    SupplierID = viewModel.SupplierID,
                    CompanyName = viewModel.CompanyName,
                    ContactName = viewModel.ContactName,
                    ContactTitle = viewModel.ContactTitle,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    Region = viewModel.Region,
                    PostalCode = viewModel.PostalCode,
                    Country = viewModel.Country,
                    Phone = viewModel.Phone,
                    Fax = viewModel.Fax,
                    HomePage = viewModel.HomePage
                };
                await _supplierService.UpdateSupplierAsync(supplierDto);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleted = await _supplierService.DeleteSupplierAsync(id);
            if (!deleted)
            {
                TempData["ErrorMessage"] = "該廠商已有商品資料無法刪除。";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}