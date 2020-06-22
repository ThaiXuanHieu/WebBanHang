using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Common;
using WebBanHang.Data.ViewModels;
using WebBanHang.Service;

namespace WebBanHang.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            ViewBag.Categories = categoryService.GetAll();
            ViewBag.Products = productService.GetAll();
            return View();
        }

        public ActionResult Category(int id)
        {
            ViewBag.Category = categoryService.GetById(id);
            ViewBag.Categories = categoryService.GetAll();
            var cart = Session[UserSession.yourCart];
            var list = new List<CartViewModel>();
            if(cart != null)
            {
                list = (List<CartViewModel>)cart;
                ViewBag.CountItem = list.Count;
            }
            else
            {
                ViewBag.CountItem = 0;
            }
            return View(productService.GetByCategoryId(id));
        }

    }
}