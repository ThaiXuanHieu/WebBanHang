using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Service;

namespace WebBanHang.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        // GET: Product
        public ActionResult SearchProduct(string productName)
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            var product = productService.GetById(id);
            ViewBag.CategoryName = categoryService.GetById(Convert.ToInt32(product.CategoryId)).CategoryName;
            ViewBag.Categories = categoryService.GetAll();
            return View(product);
        }
    }
}