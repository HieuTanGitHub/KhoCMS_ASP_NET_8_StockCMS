using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagementMVC.Models;
using StockManagementMVC.Repository;

namespace StockManagementMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Nhân viên")]
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly DataContext _dbContext;
        public SupplierController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var suppliers = _dbContext.Supplier.ToList();
            return View(suppliers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupplierModel supplier)
        {
            if (ModelState.IsValid)
            {
                var supplierModel = new SupplierModel();

                _dbContext.Supplier.Add(supplier);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Thêm nhà cung cấp thành công.";
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _dbContext.Supplier.Find(id);
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SupplierModel supplier)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Supplier.Update(supplier);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Cập nhật nhà cung cấp thành công.";
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var supplier = _dbContext.Supplier.Find(id);
            if (supplier != null)
            {
                _dbContext.Supplier.Remove(supplier);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "Xóa nhà cung cấp thành công.";
            }
            return RedirectToAction("Index");
        }
    }
}
