using JiaYu.Models;
using JiaYu.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevStudio.Securitys;

namespace JiaYu.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        
        public ActionResult List()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var datas = db.Member.OrderBy(m => m.user_id).ToList();
                return View(datas);
            }
        }

        [LoginAuthorize(RoleNo = "User")]
        public ActionResult Index(int id = 0, int code = -1)
        {
            UserAccount.UserStatus = id;
            if (code == -1)
            { if (UserAccount.UserCode == -1) UserAccount.UserCode = 0; }
            else
                UserAccount.UserCode = code;

            using (JiaYuEntities db = new JiaYuEntities())
            {
                string query = "select od.rowid,od.order_no,od.order_closed,od.user_no,od.order_date,od.order_status as status_no,od.receive_name,od.receive_address,od.remark ,ps.mname as payment_name,ss.mname as status_name,mr.m_name as user_name,mr.email,sh.mname as shipping_name from orders as od ,Payments as ps, Status as ss ,Member as mr ,Shippings as sh where od.payment_no = ps.mno and od.order_status = ss.mno and od.user_no = mr.user_id and od.shipping_no = sh.mno and od.order_closed =" + UserAccount.UserCode + "and od.user_no ='"+ UserAccount.user_id+"'" ;
                var model = db.Database.SqlQuery<UncloseViewModel>(query).ToList();
                if (model.Count == 0)
                {
                    TempData["message"] = "無任何訂單資料!!";
                    return View();
                }
                return View(model);
            }
            
        }
        [HttpGet]
        [LoginAuthorize(RoleNo = "User")]
        public ActionResult OrderDetails(int id = 0)
        {
           
            using (JiaYuEntities db = new JiaYuEntities())
            {
                string str_order_no = "";
                
                string query = "select od.rowid,od.order_no,od.order_closed,od.user_no,od.order_date,od.order_status as status_no,od.receive_name,od.receive_address,od.remark ,ps.mname as payment_name,ss.mname as status_name,mr.m_name as user_name,mr.email,sh.mname as shipping_name from orders as od ,Payments as ps, Status as ss ,Member as mr ,Shippings as sh where od.payment_no = ps.mno and od.order_status = ss.mno and od.user_no = mr.user_id and od.shipping_no = sh.mno  and od.rowid='" + id + "'";
                var order = db.Database.SqlQuery<UncloseViewModel>(query).ToList();
                if (order.Count > 0) str_order_no = order[0].order_no;

                var details = db.OrdersDetail.Where(m => m.order_no == str_order_no).ToList();
                ViewBag.OrderNo = str_order_no;
                ViewBag.OrderList = order;
                return View(details);
            }
        }
        [HttpGet]
        [LoginAuthorize(RoleNo = "User")]
        public ActionResult ReturnProduct(int id = 0)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var model = db.Orders.Where(m => m.rowid == id).FirstOrDefault();
                if (model != null)
                {
                    if (Shop.IsUnCloseOrder(model.order_status))
                    {
                        model.order_status = "RT";
                        model.order_closed = 1;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "User", new { id = UserAccount.UserStatus, code = UserAccount.UserCode });
        }
        [HttpGet]
        [LoginAuthorize(RoleNo = "User")]
        public ActionResult CancelOrder(int id = 0)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var model = db.Orders.Where(m => m.rowid == id).FirstOrDefault();
                if (model != null)
                {
                    if (Shop.IsUnCloseOrder(model.order_status))
                    {
                        model.order_status = "OR";
                        model.order_closed = 1;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "User", new { id = UserAccount.UserStatus, code = UserAccount.UserCode });
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            UserAccount.Login(model);
            if (UserAccount.Role == EnumList.LoginRole.Guest)
            {
                TempData["message"] = UserAccount.ErrorMessage;
                return View("MessagePage");
            }
            if (UserAccount.Role == EnumList.LoginRole.Admin) return RedirectToAction("Index", "Admin");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            UserAccount.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        
        public ActionResult Create()
        {
            Member model = new Member()
            {
                birthday = DateTime.Today,
                reg_date = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Member model)
        {
           // ModelState.Remove("passwd");
           // ModelState.Remove("user_id");
            if (!ModelState.IsValid) return View(model);
            using (JiaYuEntities db = new JiaYuEntities())
            {
                using (Cryptographys cryp = new Cryptographys())
                {
                    model.passwd = cryp.SHA256Encode(model.passwd);
                   
                    db.Member.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
        }
        [HttpGet]
        public ActionResult Edit(string uid)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var model = db.Member.Where(m => m.user_id == uid).FirstOrDefault();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(Member model)
        {
            ModelState.Remove("passwd");
            if (!ModelState.IsValid) return View(model);
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Member.Where(m => m.user_id == model.user_id).FirstOrDefault();
                if (data == null) return View(model);
                data.m_name = model.m_name;
                data.telephone = model.telephone;
                data.cellphone = model.cellphone;
                
                data.email = model.email;
                data.address = model.address;
                data.id_number = model.id_number;
                data.sex = model.sex;
                data.birthday = model.birthday;
               
                db.SaveChanges();
                // return RedirectToAction("List");
                TempData["message"] = "會員資料修改成功!!";
                return View(model);
               
            }
        }
        [HttpGet]
        public ActionResult Delete(string uid)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Member.Where(m => m.user_id == uid).FirstOrDefault();
                if (data != null)
                {
                    db.Member.Remove(data);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            using (Cryptographys cryp = new Cryptographys())
            {
                string str_password = cryp.SHA256Encode(model.CurrentPassword);
                using (JiaYuEntities db = new JiaYuEntities())
                {
                    TempData["MessageHeader"] = "使用者密碼變更";
                    var data = db.Member.Where(m => m.user_id == UserAccount.user_id)
                                        .Where(m => m.passwd == str_password)
                                        .Where(m => m.verify == true).FirstOrDefault();
                    if (data != null)
                    {
                        string new_password = cryp.SHA256Encode(model.NewPassword);
                        data.passwd = new_password;
                        db.SaveChanges();
                        TempData["MessageText"] = "密碼已更新,下次登入請使用新的密碼!!";
                    }
                    else
                    {
                        TempData["MessageText"] = "帳號不存在 , 密碼未更新!!";
                    }
                    return RedirectToAction("MessagePage");
                    //return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
           
            RegisterViewModel model = new RegisterViewModel()
            {
                birthday = DateTime.Today,
                reg_date = DateTime.Now,
            };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Member.Where(m => m.user_id == model.user_id).FirstOrDefault();
                if (data != null)
                {
                    ModelState.AddModelError("user_id", "帳號重覆註冊!!");
                    return View(model);
                }
                data = db.Member.Where(m => m.email == model.email).FirstOrDefault();
                if (data != null)
                {
                    ModelState.AddModelError("email", "電子信箱重覆註冊!!");
                    return View(model);
                }

                using (Cryptographys cryp = new Cryptographys())
                {
                  
                    Member new_user = new Member();
                    new_user.user_id = model.user_id;
                    new_user.m_name = model.m_name;
                    //new_user.role_no = "U";
                    new_user.verify = false;
                    new_user.reg_date =  DateTime.Now;
                    new_user.id_number = model.id_number;
                    new_user.sex = model.sex;
                    new_user.telephone = model.telephone;
                    new_user.cellphone = model.cellphone;
                    new_user.address = model.address;
                    new_user.passwd = cryp.SHA256Encode(model.passwd);
                    new_user.email= model.email;
                    new_user.remark = Guid.NewGuid().ToString().Replace("-", "").ToLower();
                    new_user.birthday = model.birthday;


                    db.Member.Add(new_user);
                    db.SaveChanges();

                    //寄出註冊驗證信件
                    string str_message = "";
                    using (AppMail mail = new AppMail())
                    {
                        str_message = mail.UserRegister(model.user_id);
                    }
                    TempData["MessageHeader"] = "使用者註冊通知";
                    TempData["MessageText"] = (string.IsNullOrEmpty(str_message)) ? "系統已寄出一封確認信至"+ model.email + ",請檢查!!" : str_message;

                }
                return RedirectToAction("MessagePage");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Verify(string id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                bool bln_valid = false;
                TempData["MessageHeader"] = "使用者註冊電子信箱驗證";
                var data = db.Member.Where(m => m.remark == id).FirstOrDefault();
                if (data == null)
                {
                    TempData["MessageText"] = "驗證碼找不到!!";
                    return RedirectToAction("MessagePage");
                }
                bln_valid = data.verify;
                if (bln_valid)
                {
                    TempData["MessageText"] = "帳號電子信箱已驗證過,不可重覆驗證!!";
                    return RedirectToAction("MessagePage");
                }

                data.remark = "";
                data.verify = true;
                db.SaveChanges();
                TempData["MessageText"] = "帳號電子信箱已驗證成功!!";
                return RedirectToAction("MessagePage");
            }
        }
    
       
        public ActionResult ForgetResetPwd(string id)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                bool bln_valid = false;
                TempData["MessageHeader"] = "使用者註冊電子信箱驗證";
                var data = db.Member.Where(m => m.remark == id).FirstOrDefault();
                if (data == null)
                {
                    TempData["MessageText"] = "驗證碼找不到!!";
                    return RedirectToAction("MessagePage");
                }
                bln_valid = data.verify;
                if (bln_valid)
                {
                    TempData["MessageText"] = "帳號電子信箱已驗證過,不可重覆驗證!!";
                    return RedirectToAction("MessagePage");
                }
            }

            ForgetResetPwdViewModel model = new ForgetResetPwdViewModel()
            {
                remark = id
            };
            
            return View(model);
            
        }
      
        [HttpPost]
        public ActionResult ForgetResetPwd(ForgetResetPwdViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            using (Cryptographys cryp = new Cryptographys())
            {

                  using (JiaYuEntities db = new JiaYuEntities())
                  {
                            TempData["MessageHeader"] = "使用者密碼變更";
                            var data = db.Member.Where(m => m.remark == model.remark).FirstOrDefault();
                            if (data != null)
                            {
                                string new_password = cryp.SHA256Encode(model.NewPassword);
                                data.passwd = new_password;
                                data.verify = true;
                                data.remark = "";
                                
                                db.SaveChanges();
                                TempData["MessageText"] = "密碼已更新,下次登入請使用新的密碼!!";
                            }
                            else
                            {
                                TempData["MessageText"] = "帳號不存在 , 密碼未更新!!";
                            }
                            return RedirectToAction("MessagePage");
                          
                  }
            }
        }
     
        [HttpGet]
        public ActionResult Forget()
        {
            ForgetPwdViewModel model = new ForgetPwdViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Forget(ForgetPwdViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            using (JiaYuEntities db = new JiaYuEntities())
            {

                var data = db.Member.Where(m => m.email == model.email).FirstOrDefault();

                if (data == null)
                {
                    ModelState.AddModelError("email", "無此電子郵箱!!");
                    return View(model);
                }

                data.remark = Guid.NewGuid().ToString().Replace("-", "").ToLower();
                data.verify = false;
                db.SaveChanges();
                string str_message = "";
                using (AppMail mail = new AppMail())
                {
                    str_message = mail.UserForget(data.user_id);
                }
                TempData["MessageHeader"] = "使用者忘記密碼通知";
                TempData["MessageText"] = (string.IsNullOrEmpty(str_message)) ? "系統已寄出一封確認信至" + model.email + ",請檢查!!" : str_message;
              
            }
            return RedirectToAction("MessagePage");
        }
   
        [HttpGet]
        public ActionResult MessagePage()
        {
            ViewBag.MessageHeader = TempData["MessageHeader"].ToString();
            ViewBag.MessageText = TempData["MessageText"].ToString();
            return View();
        }
    }
}