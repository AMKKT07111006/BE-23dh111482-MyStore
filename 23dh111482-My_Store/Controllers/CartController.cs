using _23dh111482_My_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23dh111482_My_Store.Models;
using _23dh111482_My_Store.Models.ViewModel;

namespace _23dh111482_My_Store.Controllers
{
    public class CartController : Controller
    {
        //private readonly ApplicationDbContext db = new ApplicationDbContext;
        private My_StoreEntities db = new My_StoreEntities();

        //lấy dịch vụ giỏ hàng
        private CartService GetCartService()
        {
            return new CartService(Session);
        }

        // hiển thị giỏ hàng không gom nhóm theo danh mục
        public ActionResult Index()
        {
            var cart = GetCartService().GetCart();
            return View(cart);
        }


        //thêm sản phẩm vào giỏ hàng(gồm 1 action dạng Post)
        public ActionResult AddToCart(int id, int quantity = 1)
        {
            var product = db.Products.Find(id);
            if(product != null)
            {
                var cartService = GetCartService();
                cartService.GetCart().AddItem(product.ProductID,product.ProductImage, product.ProductName, product.ProductPrice
                    , quantity, product.Category.CategoryName);
            }

            return RedirectToAction("Index");
        }

        //bỏ 1 sản phẩm khỏi giỏ hàng(gồm 1 action dạng Post)
        public ActionResult RemoveFromCart(int id)
        {
            var cartService = GetCartService();
            cartService.GetCart().RemoveItem(id);
            return RedirectToAction("Index");
        }

        //Xóa hết các sản phẩm trong giỏ hàng
        public ActionResult ClearCart()
        {
            GetCartService().ClearCart();
            return RedirectToAction("Index");
        }

        [HttpPost]
        //Cập nhật số lượng của 1 sản phẩm trong giỏ hàng
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            var cartService = GetCartService();
            cartService.GetCart().UpdateQuantity(id, quantity);
            return RedirectToAction("Index");
        }


    }
}