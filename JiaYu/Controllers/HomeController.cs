using JiaYu.Models;
using JiaYu.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaYu.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
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
        public ActionResult Category(string id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            { 
                string query = "select pr.pro_id,pr.pname,pr.spec,pr.price_sale,(select top 1 filename from Photo where pro_id = pr.pro_id) as filename from Product as pr where pr.categoryid='"+id+"'";
                var data = db.Database.SqlQuery<CategoryProductViewModel>(query).ToList();
                if (data.Count==0)
                {
                    TempData["message"] = "此分類,暫無任何資料!!";
                    return View();
                }
                return View(data);

            }

        }
        public ActionResult ProductDetails(string id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var product = db.Product.Where(m => m.pro_id == id).FirstOrDefault();
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                Shop.ProductNo = id;
                List<SelectListItem> crlist = Shop.GetPropertyList(Shop.ProductNo);
                ProductDetailViewModel model = new ProductDetailViewModel()
                {
                    pro_id = product.pro_id,
                    pname = product.pname,
                    price_sale = product.price_sale,
                    memory = product.memory,
                    spec = product.spec,
                    remark = product.remark,
                    qty = 1,
                    color_no = "",
                    photos = db.Photo.Where(m => m.pro_id == product.pro_id).OrderBy(m => m.rowid).ToList(),
                    selectColorList = crlist
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult ProductDetails(FormCollection collection)
        {
            int int_qty = 0;
            string str_color_no = collection["color_no"];
           
            int.TryParse(collection["qty"].ToString(), out int_qty);
            string color_name = Shop.GetColorName(str_color_no);
            List<SelectListItem> crlist = Shop.GetPropertyList(Shop.ProductNo);

            using (JiaYuEntities db = new JiaYuEntities())
            {
                var product = db.Product.Where(m => m.pro_id == Shop.ProductNo).FirstOrDefault();
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                ProductDetailViewModel model = new ProductDetailViewModel()
                {
                    pro_id = Shop.ProductNo,
                    pname = product.pname,
                    price_sale = product.price_sale,
                    memory = product.memory,
                    spec = product.spec,
                    remark = product.remark,
                    qty = int_qty,
                    color_no = str_color_no,
                    photos = db.Photo.Where(m => m.pro_id == product.pro_id).OrderBy(m => m.rowid).ToList(),
                    selectColorList = crlist
                };
                string spec_str = product.pname + "," + product.memory + "," + color_name;
                Cart.AddCart(Shop.ProductNo, spec_str, int_qty);
                return RedirectToAction("ProductDetails", "Home", new { id = Shop.ProductNo });
            }
        }

      
    }
}