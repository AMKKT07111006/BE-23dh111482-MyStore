﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23dh111482_My_Store.Models;
using _23dh111482_My_Store.Models.ViewModel;
using PagedList.Mvc;
using PagedList;
using System.Threading;

namespace _23dh111482_My_Store.Controllers
{
    public class HomeController : Controller
    {
        private My_StoreEntities db = new My_StoreEntities();
        public ActionResult Index(string searchTerm, int? page)
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();

            //Tìm kiếm dựa trên từ khóa
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p => p.ProductName.Contains(searchTerm)
                                    || p.ProductDescription.Contains(searchTerm)
                                    || p.Category.CategoryName.Contains(searchTerm));
            }

            //Đoạn code liên quan tới phân trang
            //Lấy số trang hiện tại(mặc định là trang 1 nếu không có giá trị)
            int pageNumber = page ?? 1;
            int pageSize = 6; //Số sản phẩm mỗi trang

            //lấy top 10 sp bán chạy nhất
            model.FeaturedProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);
            //count() đang tính theo số lượt mua
            //tính theo tổng số lượng mua thì sửa thành Sum().Quantity

            //lấy 20 sp bán chậm nhất và phân trang 
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        //GET: HOME/ProductDetail/5
        public ActionResult ProductDetail(int? id, int? quantity, int? page) 
        {
            //id mã sản phẩm, quantity số lượng đặt mua,
            //page vị trí phần phân trang của các sản phẩm bán chạy
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);

            if (pro == null)
            {
                return HttpNotFound();
            } 
            
            //lấy tất cả sản phẩm cùng danh mục 
            var products = db.Products.Where(p => p.CategoryID == pro.CategoryID && p.ProductID != pro.ProductID).AsQueryable();

            ProductDetailVM model = new ProductDetailVM();

            //Đoạn code liên quan tới phân trang
            //lấy số trang hiện tại(mặc định là 1 nếu không có giá trị)
            int pageNumber = page ?? 1;
            int pageSize = model.PageSize; //số sản phẩm mỗi trang
            model.product = pro;
            model.RelatedProducts = products.OrderBy(p => p.ProductID).Take(8).ToPagedList(pageNumber, pageSize);
            model.TopProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(8).ToPagedList(pageNumber, pageSize);

            if(quantity.HasValue)
            {
                model.quantity = quantity.Value;    
            }    

            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}