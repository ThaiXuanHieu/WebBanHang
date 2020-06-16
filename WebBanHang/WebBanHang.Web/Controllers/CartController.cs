using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.ViewModels;
using WebBanHang.Service;

namespace WebBanHang.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        private const string yourCart = "YourCart";

        public CartController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;


        }
        // GET: Cart
        public ActionResult Index()
        {
            decimal Amount = 0;
            var cart = Session[yourCart];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
                foreach(var item in list)
                {
                    Amount += Convert.ToDecimal(item.Quantity * item.Product.NewPrice);
                }
                ViewBag.Amount = Amount;
                ViewBag.Categories = categoryService.GetAll();
                return View(list);
            }
            else
            {
                TempData["NotFoundMessage"] = "Không có sản phẩm nào trong giỏ hàng của bạn.";
                ViewBag.Categories = categoryService.GetAll();
                return View(list);
            }
        }

        public ActionResult AddToCart(int id)
        {
            var product = productService.GetById(id);
            var cart = Session[yourCart];
            if (cart != null)
            {
                var list = (List<CartViewModel>)cart;
                if (list.Exists(p => p.Product.ProductId == id))
                {
                    foreach (var item in list)
                    {
                        item.Quantity += 1;
                    }
                }
                else
                {
                    var item = new CartViewModel();
                    item.Product = product;
                    item.Quantity = 1;
                    list.Add(item);
                }
                Session[yourCart] = list;
                
            }
            else
            {
                var item = new CartViewModel();
                item.Product = product;
                item.Quantity = 1;
                var list = new List<CartViewModel>();
                list.Add(item);
                Session[yourCart] = list;
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItem(int id)
        {
            var cart = Session[yourCart];
            var list = (List<CartViewModel>)cart;
            var product = productService.GetById(id);
            if(list.Exists(p => p.Product.ProductId == id))
            {
                var item = list.Where(p => p.Product.ProductId == id).FirstOrDefault();
                list.Remove(item);
                if(list.Count == 0)
                {
                    list = null;
                }
                Session[yourCart] = list;
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}