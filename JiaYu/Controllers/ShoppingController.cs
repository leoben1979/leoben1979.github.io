using JiaYu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JiaYu.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }

        [LoginAuthorize(Roles = "Guest,Member")]
        public ActionResult CartList()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                if (UserAccount.IsLogin)
                {
                    var data1 = db.Carts
                        .Where(m => m.user_id == UserAccount.user_id)
                        .ToList();
                    return View(data1);
                }
                var data2 = db.Carts
                   .Where(m => m.lot_no == Cart.LotNo)
                   .ToList();
                return View(data2);
            }
        }

        [LoginAuthorize(Roles = "Guest,Member")]
        public ActionResult CartPlus(int id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Carts
                 .Where(m => m.rowid == id)
                 .FirstOrDefault();
                if (data != null)
                {
                    data.qty += 1;
                    data.amount = data.qty * data.price;
                    db.SaveChanges();
                }
                return RedirectToAction("CartList");
            }
         
        }

        [LoginAuthorize(Roles = "Guest,Member")]
        public ActionResult CartMinus(int id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Carts
                 .Where(m => m.rowid == id)
                 .FirstOrDefault();
                if (data != null)
                {
                    if (data.qty > 1)
                    {
                        data.qty -= 1;
                        data.amount = data.qty * data.price;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("CartList");
            }
    
        }

        [LoginAuthorize(Roles = "Guest,Member")]
        public ActionResult CartDelete(int id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Carts
                  .Where(m => m.rowid == id)
                  .FirstOrDefault();
                if (data != null)
                {
                    db.Carts.Remove(data);
                    db.SaveChanges();
                }
                return RedirectToAction("CartList");
            }
        
        }
        [LoginAuthorize(Roles = "Member")]
        public ActionResult Checkout()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                cvmOrders models = new cvmOrders()
                {
                    receive_name = "",
                    receive_email = "",
                    receive_address = "",
                    payment_no = "01",
                    shipping_no = "01",
                    remark = "",
                    PaymentsList = db.Payments.OrderBy(m => m.mno).ToList(),
                    ShippingsList = db.Shippings.OrderBy(m => m.mno).ToList()
                };

                return View(models);
            }
            
        }
        [HttpPost]
        [LoginAuthorize(Roles = "Member")]
        public ActionResult Checkout(cvmOrders model)
        {
            if (!ModelState.IsValid)
            {
                using (JiaYuEntities db = new JiaYuEntities())
                {
                    if (model.PaymentsList == null)
                    {
                        model.PaymentsList = db.Payments.OrderBy(m => m.mno).ToList();
                    }
                    if (model.ShippingsList == null)
                    {
                        model.ShippingsList = db.Shippings.OrderBy(m => m.mno).ToList();
                    }
                    return View(model);
                }
    
            }

            Cart.CartPayment(model);

            return Redirect("~/ECPayment.aspx");
        }
        public ActionResult CheckoutReport()
        {
            return View();
        }
    }
}