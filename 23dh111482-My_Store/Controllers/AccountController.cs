using _23dh111482_My_Store.Models;
using _23dh111482_My_Store.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Policy;
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;
using System.Web.Security;
using _23dh111482_My_Store.Models.ViewModel;
using _23dh111482_My_Store.Models;
using System.Web.UI.WebControls;

namespace _23DH114201_My_Store.Controllers
{
    public class AccountController : Controller
    {
        My_StoreEntities db = new My_StoreEntities();
        // GET: Account/Register

        public ActionResult Register()
        {
            return View();

        }
        // POST: Account/Register

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.SingleOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập này đã tồn tại!");
                    return View(model);
                }
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    UserRole = "Customer"
                };
                db.Users.Add(user);
                var customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,
                    CustomerAddress = model.CustomerAddress,
                    Username = model.Username,
                };
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // POST: Account/Login
        public ActionResult Login()
        {
            return View();

        }
        // POST: Account/Register

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Username == model.Username
                    && u.Password == model.Password
                    && u.UserRole == "Customer");
                if (user != null)
                {
                    //Lưu trạng thái đăng nhập vào session
                    Session["Username"] = user.Username;
                    Session["UserRole"] = user.UserRole;

                    //Lưu thông tin xác thực người dùng vào cookie
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    return RedirectToActionPermanent("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }
    }
}