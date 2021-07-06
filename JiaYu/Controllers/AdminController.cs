using JiaYu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DevStudio.Securitys;

namespace JiaYu.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(FormCollection collection)
        {
            string str_text = collection["searchText"];
            return RedirectToAction("List", "Admin", new { page = AppService.PageNo, pageSize = AppService.PageSize, searchText = str_text });
        }
        [HttpGet]
        public ActionResult List(int page = 1, int pageSize = 10, string searchText = "")
        {       
                return View(GetPageList("AdminList", page, pageSize, searchText));
        }
        private IPagedList<Member> GetPageList(string pageType, int page, int pageSize, string searchText = "")
        {
            AppService.PageType = pageType;
            AppService.PageNo = page;
            AppService.PageSize = pageSize;
            AppService.SearchText = searchText;
            //if (pageType == "AdminList") return SetMemberList(GetMemberList());
            return SetMemberList(GetMemberList());
        }
        private IPagedList<Member> GetMemberList()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                if (string.IsNullOrEmpty(AppService.SearchText))
                {
                    var datas1 = db.Member.OrderBy(m => m.user_id)
                        .ToPagedList(AppService.PageNo, AppService.PageSize);
                    return datas1;
                }
                //先置換(temp)文字
                var temp = SetMemberList(db.Member.OrderBy(model => model.user_id)
                    .ToPagedList(AppService.PageNo, AppService.PageSize));
                ////再搜尋(temp)文字
                var datas2 = temp.Where(m =>
                    m.user_id.Contains(AppService.SearchText) ||
                    m.m_name.Contains(AppService.SearchText) ||
                    m.id_number.Contains(AppService.SearchText) ||
                    m.sex.Contains(AppService.SearchText) ||
                    m.cellphone.Contains(AppService.SearchText) ||
                    m.telephone.Contains(AppService.SearchText))
                        .OrderBy(model => model.user_id)
                        .ToPagedList(AppService.PageNo, AppService.PageSize);
                return datas2;
            }
        }
        private IPagedList<Member> SetMemberList(IPagedList<Member> member)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                if (member.Count > 0)
                {
                    string value1 = "";
                    for (int i = 0; i < member.Count; i++)
                    {
                        value1 = member[i].sex;
                        var data1 = (value1.Equals("M") || value1.Equals("男")) ? "男" : "女";
                        member[i].sex = (data1 == null) ? member[i].sex : data1;
                    }
                }
                return member;
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            Member model = new Member()
            {
                birthday = DateTime.Today,
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
                var data = db.Member.Where(m => m.user_id == model.user_id).FirstOrDefault();
                if (data != null)
                {
                    ModelState.AddModelError("user_id", "己有此帳號註冊!!");
                    return View(model);
                }
                data = db.Member.Where(m => m.email == model.email).FirstOrDefault();
                if (data != null)
                {
                    ModelState.AddModelError("email", "己有此電子信箱註冊!!");
                    return View(model);
                }
                data = db.Member.Where(m => m.id_number == model.id_number).FirstOrDefault();
                if (data != null)
                {
                    ModelState.AddModelError("id_number", "己有此身份證號註冊!!");
                    return View(model);
                }
                using (Cryptographys cryp = new Cryptographys())
                {
                    model.passwd = cryp.SHA256Encode(model.passwd);
                    model.reg_date = DateTime.Now;
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
    }
}