using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityCafeteria.Data;
using UniversityCafeteria5.Models;

namespace UniversityCafeteria5.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض كل المنتجات
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // عرض نموذج إضافة منتج
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var suppliers = _context.Suppliers.ToList();

            ViewBag.Categories = new SelectList(
                categories,
                nameof(Category.ID),
                nameof(Category.Name));

            ViewBag.Suppliers = new SelectList(
                suppliers,
                nameof(Supplier.ID),
                nameof(Supplier.Name));

            return View();
        }

        // حفظ المنتج
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // إعادة تحميل القوائم إذا رجعنا للنموذج بسبب خطأ بالبيانات
            var categories = _context.Categories.ToList();
            var suppliers = _context.Suppliers.ToList();

            ViewBag.Categories = new SelectList(
                categories,
                nameof(Category.ID),
                nameof(Category.Name),
                product.CategoryID);

            ViewBag.Suppliers = new SelectList(
                suppliers,
                nameof(Supplier.ID),
                nameof(Supplier.Name),
                product.SupplierID);

            return View(product);
        }
    }
}