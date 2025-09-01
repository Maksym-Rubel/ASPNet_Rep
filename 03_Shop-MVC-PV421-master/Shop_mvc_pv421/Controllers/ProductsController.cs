using Microsoft.AspNetCore.Mvc;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Data.Entities;

namespace Shop_mvc_pv421.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext ctx;
        public class ProductCategoryViewModel
        {
            public List<Product> Products { get; set; }
            public List<Category> Categories { get; set; }
        }
        public ProductsController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {

            var model = ctx.Products.ToList();
            var category = ctx.Categories.ToList();
     
            var vm = new ProductCategoryViewModel()
            {
                Products = model,
                Categories = category
            };

            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();

            ctx.Products.Remove(product);
            ctx.SaveChanges(); // submit changes to DB

            return RedirectToAction("Index");
        }


        public IActionResult ProductView(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);

         
        }
    }
}
