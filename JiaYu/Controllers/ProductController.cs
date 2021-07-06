using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaYu.Models;
using JiaYu.Models.ViewModel;
using PagedList;

namespace JiaYu.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> repo_product { get; set; }

        public ProductController()
        {
            repo_product = new EFGenericRepository<Product>(new JiaYuEntities());

        }
        public ActionResult Search(FormCollection collection)
        {
            string str_text = collection["searchText"];
            return RedirectToAction("Index", "Product", new { page = AppService.PageNo, pageSize = AppService.PageSize, searchText = str_text });
        }



        public ActionResult Index(int page = 1, int pageSize = 10, string searchText = "")
        {
     
                return View(GetPageList("ProductList", page, pageSize, searchText));
        }

        private IPagedList<Product> GetPageList(string pageType, int page, int pageSize, string searchText = "")
        {
            AppService.PageType = pageType;
            AppService.PageNo = page;
            AppService.PageSize = pageSize;
            AppService.SearchText = searchText;

            return SetProductList(GetProductList());
        }

        private IPagedList<Product> GetProductList()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                if (string.IsNullOrEmpty(AppService.SearchText))
                {
                    var datas1 = db.Product.OrderBy(m => m.pro_id)
                        .ToPagedList(AppService.PageNo, AppService.PageSize);
                    return datas1;
                }
                //先置換(temp)文字
                var temp = SetProductList(db.Product.OrderBy(model => model.pro_id)
                    .ToPagedList(AppService.PageNo, AppService.PageSize));
                ////再搜尋(temp)文字
                var datas2 = temp.Where(m =>
                    m.pro_id.Contains(AppService.SearchText) ||
                    m.pname.Contains(AppService.SearchText) ||
                    m.categoryid.Contains(AppService.SearchText) ||
                    m.memory.Contains(AppService.SearchText) )
                    .OrderBy(model => model.pro_id)
                    .ToPagedList(AppService.PageNo, AppService.PageSize);
                return datas2;
            }
        }
        private IPagedList<Product> SetProductList(IPagedList<Product> product)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                if (product.Count > 0)
                {
                    string value1 = ""; 
                    //string value2 = ""; string value3 = "";
                    for (int i = 0; i < product.Count; i++)
                    {
                        value1 = product[i].categoryid;


                        var data1 = db.Category.Where(m => m.cate_id == value1).FirstOrDefault();

                        product[i].categoryid = (data1 == null) ? product[i].categoryid : data1.ca_name;

                    }
                }
                return product;
            }
        }

        public ActionResult Create()
        {
            JiaYuEntities db = new JiaYuEntities();

            ProductCreateViewModel model = new ProductCreateViewModel()
            {
                categoryList = db.Category.Where(m => m.super_id == null).OrderBy(m => m.cate_id).ToList(),
                colorList = new List<string>(),
                selectColorList = getColor()
                   

             };
          
                return View(model);     
        }

        [HttpPost]
        public ActionResult Create(ProductCreateViewModel model)
        {
    
            if (!ModelState.IsValid) return View(model);
            using (JiaYuEntities db = new JiaYuEntities())
            {
                ModelState.Remove("pro_id");
               
                Product data2 = new Product();
                data2.pro_id = GetProSerial();
                data2.pname = model.pname;
                data2.categoryid = model.cateid_2;
                data2.price_sale = model.price_sale;
                data2.memory = model.memory;
                data2.spec = model.spec;
                data2.color = model.color;
                data2.Browse_time = model.Browse_time;
                data2.remark = model.remark;
                data2.Is_hot = model.is_hot;
                data2.is_sales = false;
                data2.Is_top = false;
                data2.ven_id = "V01";
                db.Product.Add(data2);

                string FileName = "";
                var i = 1;
               
                foreach (HttpPostedFileBase file in model.ImageFile)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = i.ToString().PadLeft(2, '0'); ;
                        var FileExtension = Path.GetExtension(file.FileName);
                        FileName = data2.pro_id + "-" + InputFileName.Trim() + FileExtension;
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Images/Product/") + FileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        Photo img = new Photo();
                        img.pro_id = data2.pro_id;
                        img.filename = FileName;
                        db.Photo.Add(img);

                        i++;

                    }

                }
               
                foreach (var item in model.colorList)
                {
                    ColorRelation CtData = new ColorRelation();
                    CtData.color_no = Int32.Parse(item);
                    CtData.pro_id = data2.pro_id;

                    db.ColorRelation.Add(CtData);
                }


                db.SaveChanges();
                return RedirectToAction("Index");
            }

              
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            
            JiaYuEntities db = new JiaYuEntities();
            var product = db.Product.Where(m => m.pro_id == id).FirstOrDefault();
            if (product == null)
            {
                ModelState.AddModelError("pro_id", "無此商品編號!!");
                return RedirectToAction("Index");
            }
            var cateid = db.Category.Where(m => m.cate_id == product.categoryid).FirstOrDefault();

            List<ColorRelation> crlist = db.ColorRelation.Where(m => m.pro_id == product.pro_id).OrderBy(m => m.color_no).ToList();
            List<string> crlist2 = new List<string>();

            foreach(var cno in crlist)
            {
                crlist2.Add(cno.color_no.ToString());
            }
            ProductCreateViewModel model = new ProductCreateViewModel()
            {
                
                pro_id = product.pro_id,
                pname = product.pname,
                categoryid = cateid.super_id,
                cateid_2 = product.categoryid,
                price_sale = product.price_sale,
                is_hot = (bool)product.Is_hot,
                memory = product.memory,
                spec = product.spec,
                Browse_time = product.Browse_time,
                remark = product.remark,
                categoryList = db.Category.Where(m => m.super_id == null).OrderBy(m => m.cate_id).ToList(),
                //categoryList = new List<Category>(),
                //selectCategoryList = getCategory(),
                colorList = crlist2,
                photos = db.Photo.Where(m => m.pro_id == product.pro_id).OrderBy(m => m.rowid).ToList(),
          
                selectColorList = getColor()
            };
            
            return View(model);

        }
        public ActionResult Edit(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
           
            using (JiaYuEntities db = new JiaYuEntities()) 
            {
              
                var data = db.Product.Where(m => m.pro_id == model.pro_id).FirstOrDefault();
                if (data == null) return View(model);
                data.pname = model.pname;
                data.categoryid = model.cateid_2;
                data.price_sale = model.price_sale;
                data.memory = model.memory;
                data.spec = model.spec;
                data.Browse_time = model.Browse_time;
                data.remark = model.remark;
                data.Is_hot = model.is_hot;
               
                db.SaveChanges();

                string FileName = "";
                int i = 1;
                if(model.ImageFile != null)
                {
                    foreach (HttpPostedFileBase file in model.ImageFile)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;

                            var InputFileName = (timeStamp + i).ToString();
                            var FileExtension = Path.GetExtension(file.FileName);
                            FileName = model.pro_id + "-" + InputFileName.Trim() + FileExtension;
                            var ServerSavePath = Path.Combine(Server.MapPath("~/Images/Product/") + FileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                            Photo img = new Photo();
                            img.pro_id = model.pro_id;
                            img.filename = FileName;
                            db.Photo.Add(img);

                            db.SaveChanges();

                        }
                        i++;

                    }
                }
               
               
                db.ColorRelation.RemoveRange(db.ColorRelation.Where(c => c.pro_id == model.pro_id));
                db.SaveChanges();
                foreach (var item in model.colorList)
                {
                    ColorRelation ColorData = new ColorRelation();
                    ColorData.color_no = Int32.Parse(item);
                    ColorData.pro_id = model.pro_id;

                    db.ColorRelation.Add(ColorData);
                }
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = model.pro_id });
            }
                
        }

        [HttpGet]
        public ActionResult DeleteImage(string proid, int rowid, string filename)
        {
            var ServerSavePath = Server.MapPath("~/Images/Product/") + filename;

           

            if (System.IO.File.Exists(ServerSavePath))
            {
                System.IO.File.Delete(ServerSavePath);    
            }

            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.Photo.Where(m => m.rowid == rowid).FirstOrDefault();
                if (data != null)
                {
                    db.Photo.Remove(data);
                    db.SaveChanges();
                }
                return RedirectToAction("Edit", new { id = proid });
            }
            
        }
        [HttpGet]
        public ActionResult Delete(string id) 
        {
            
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var porduct = db.Product.Where(m => m.pro_id == id).FirstOrDefault();
                if (porduct != null)
                {
                    db.ColorRelation.RemoveRange(db.ColorRelation.Where(m => m.pro_id == id));
                    db.Photo.RemoveRange(db.Photo.Where(m => m.pro_id == id));
                    db.Product.Remove(porduct);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public JsonResult Cateid2(string cID)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var cdata = db.Category.Where(x => x.super_id == cID).OrderBy(x => x.cate_id).ToList();
                if (cdata.Count() > 0)
                {
                    foreach (var it in cdata)
                    {
                        items.Add(new KeyValuePair<string, string>(
                            it.cate_id,it.ca_name));
                    }
                }
           
                return this.Json(items);
            }
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="customerID">The customer ID.</param>
        /// <returns></returns>
        private IEnumerable<Category> GetCate2(string cID)
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var query = db.Category.Where(x => x.cate_id == cID).OrderBy(x => x.cate_id);
                return query.ToList();
            }
        }
        private string GetProSerial()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                string proid;
                string first_str = "Pro" + DateTime.Now.ToString("yyyyMMdd");
                var like_list = db.Product.Where(m => m.pro_id.Contains(first_str)).OrderByDescending(m => m.pro_id).FirstOrDefault();

                if (like_list == null)
                {
                    proid = first_str + "0001";
                }
                else
                {
                    var four_num = like_list.pro_id.Substring(like_list.pro_id.Length - 4, 4);
                    int num = Convert.ToInt32(four_num);
                    num += 1;
                    String end_num = num.ToString().PadLeft(4, '0');
                    proid = first_str + end_num;
                }
                return proid;
            }
        }

        private List<SelectListItem> getColor()
        {
            using (JiaYuEntities db = new JiaYuEntities())
            {
                var data = db.ColorList.OrderBy(m => m.color_no);
                List<SelectListItem> corList = new List<SelectListItem>();
                foreach (var item in data)
                {
                    corList.Add(new SelectListItem() { Text = item.color_name, Value = item.color_no.ToString() });
                }
                return corList;


            }
        }
        

    }
   
}