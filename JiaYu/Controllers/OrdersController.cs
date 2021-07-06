using JiaYu.Models;
using JiaYu.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace JiaYu.Controllers
{
    public class OrdersController : Controller
    {
       // [LoginAuthorize(Roles = "Admin")]
        public ActionResult Index(int id = 0, int code = -1)
        {
            UserAccount.UserStatus = id;
            if (code == -1)
            {
                if (UserAccount.UserCode == -1) UserAccount.UserCode = 0;
            }
            else
            {
                UserAccount.UserCode = code;
            }

            using (JiaYuEntities db = new JiaYuEntities())
            {
                string query = "select od.rowid,od.order_no,od.order_closed,od.user_no,od.order_date,od.order_status as status_no,od.receive_name,od.receive_address,od.remark ,ps.mname as payment_name,ss.mname as status_name,mr.m_name as user_name,mr.email,sh.mname as shipping_name from orders as od ,Payments as ps, Status as ss ,Member as mr ,Shippings as sh where od.payment_no = ps.mno and od.order_status = ss.mno and od.user_no = mr.user_id and od.shipping_no = sh.mno and od.order_closed =" + UserAccount.UserCode;
                var model = db.Database.SqlQuery<UncloseViewModel>(query).ToList();
                if (model.Count == 0)
                {
                    TempData["message"] = "無任何訂單資料!!";
                    return View();
                }
                return View(model);
            }
          

            /*
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var models = db.Orders
                    .Join(db.Payments, p => p.payment_no, d => d.mno,
                    (p1, d1) => new { p1, payment_name = d1.mname })
                    .Join(db.Status, p => p.p1.order_status, d => d.mno,
                    (p2, d2) => new { p2, status_name = d2.mname })
                    .Join(db.Member, p => p.p2.p1.user_no, d => d.user_id,
                    (p3, d3) => new { p3, user_name = d3.m_name })
                    .Join(db.Shippings, p => p.p3.p2.p1.shipping_no, d => d.mno,
                    (p4, d4) => new
                    {
                        rowid = p4.p3.p2.p1.rowid,
                        order_closed = p4.p3.p2.p1.order_closed,
                        user_no = p4.p3.p2.p1.user_no,
                        user_name = p4.user_name,
                        order_no = p4.p3.p2.p1.order_no,
                        order_date = p4.p3.p2.p1.order_date,
                        status_no = p4.p3.p2.p1.order_status,
                        status_name = p4.p3.status_name,
                        shipping_name = d4.mname,
                        payment_name = p4.p3.p2.payment_name,
                        receive_name = p4.p3.p2.p1.receive_name,
                        receive_address = p4.p3.p2.p1.receive_address,
                        remark = p4.p3.p2.p1.remark
                    })
                     .Where(m => m.order_closed == 0)
                     .OrderByDescending(m => m.order_no).ToList();

                //return Json(new { data = models }, JsonRequestBehavior.AllowGet);

                return View(models);
            }
            */


        }
        [HttpGet]
       // [LoginAuthorize(Roles = "Admin")]
        public ActionResult GetDataList()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var models = db.Orders
                    .Join(db.Payments, p => p.payment_no, d => d.mno,
                    (p1, d1) => new { p1, payment_name = d1.mname })
                    .Join(db.Status, p => p.p1.order_status, d => d.mno,
                    (p2, d2) => new { p2, status_name = d2.mname })
                    .Join(db.Member, p => p.p2.p1.user_no, d => d.user_id,
                    (p3, d3) => new { p3, user_name = d3.m_name })
                    .Join(db.Shippings, p => p.p3.p2.p1.shipping_no, d => d.mno,
                    (p4, d4) => new
                    {
                        rowid = p4.p3.p2.p1.rowid,
                        order_closed = p4.p3.p2.p1.order_closed,
                        user_no = p4.p3.p2.p1.user_no,
                        user_name = p4.user_name,
                        order_no = p4.p3.p2.p1.order_no,
                        order_date = p4.p3.p2.p1.order_date,
                        status_no = p4.p3.p2.p1.order_status,
                        status_name = p4.p3.status_name,
                        shipping_name = d4.mname,
                        payment_name = p4.p3.p2.payment_name,
                        receive_name = p4.p3.p2.p1.receive_name,
                        receive_address = p4.p3.p2.p1.receive_address,
                        remark = p4.p3.p2.p1.remark
                    })
                     .Where(m => m.order_closed == 0)
                     .OrderByDescending(m => m.order_no).ToList();

                return Json(new { data = models }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        //[LoginAuthorize(RoleNo = "Admin")]
        public ActionResult Details(int id = 0)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                string str_order_no = "";
                // var order = db.Orders.Where(m => m.rowid == id).FirstOrDefault();
                string query = "select od.rowid,od.order_no,od.order_closed,od.user_no,od.order_date,od.order_status as status_no,od.receive_name,od.receive_address,od.remark ,ps.mname as payment_name,ss.mname as status_name,mr.m_name as user_name,mr.email,sh.mname as shipping_name from orders as od ,Payments as ps, Status as ss ,Member as mr ,Shippings as sh where od.payment_no = ps.mno and od.order_status = ss.mno and od.user_no = mr.user_id and od.shipping_no = sh.mno  and od.rowid='"+id+"'";
                var order = db.Database.SqlQuery<UncloseViewModel>(query).ToList();
                if(order.Count >0)  str_order_no = order[0].order_no;
               
                var details = db.OrdersDetail.Where(m => m.order_no == str_order_no).ToList();
                ViewBag.OrderNo = str_order_no;
                ViewBag.OrderList = order;
                return View(details);
            }
        }
        [HttpGet]
        [LoginAuthorize(RoleNo = "Admin")]
        public ActionResult ChangeStatus(int id = 0)
        {
            string str_status = "ON";
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var model = db.Orders.Where(m => m.rowid == id).FirstOrDefault();
                if (model != null) str_status = model.order_status;

                var selectList = new List<SelectListItem>();
                List<Status> lists = Shop.GetStatusList();
                foreach (var item in lists)
                {
                    SelectListItem list = new SelectListItem();
                    list.Value = item.mno;
                    list.Text = item.mname;
                    selectList.Add(list);
                }
                //預設選擇哪一筆
                selectList.Where(m => m.Value == str_status).First().Selected = true;

                ViewBag.SelectList = selectList;
                return View(model);
            }
        }
        [HttpPost]
        [LoginAuthorize(RoleNo = "Admin")]
        public ActionResult ChangeStatus(Orders model)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                bool status = false;
                var orders = db.Orders.Where(m => m.order_no == model.order_no).FirstOrDefault();
                if (orders != null)
                {
                    orders.order_status = model.order_status;
                    orders.order_closed = Shop.GetOrderClosed(model.order_status);
                    orders.order_validate = Shop.GetOrderValidate(model.order_status);
                    db.SaveChanges();
                    status = true;
                }
                return RedirectToAction("Index", "Orders", new { id = UserAccount.UserStatus, code = UserAccount.UserCode });
            }
        }
    }
}