using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaYu.Models.ViewModel
{
    public class ProductCreateViewModel
    {
       
        [Display(Name = "熱門")]
        public bool is_hot { get; set; }
       

        [Key]
        [Display(Name = "商品編號")]
        public string pro_id { get; set; }

        [Display(Name = "商品名稱")]
        [DisplayFormat(ConvertEmptyStringToNull = false, HtmlEncode = true, NullDisplayText = "請輸入商品名稱")]
        public string pname { get; set; }

        [Display(Name = "分類")]
        public string categoryid { get; set; }
        public string cateid_2 { get; set; }


        [Display(Name = "銷售單價")]
        [Required(ErrorMessage = "銷售單價不可空白")]
        public int price_sale { get; set; }

        [Display(Name = "記憶體容量")]
        [Required(ErrorMessage = "記憶體容量不可空白")]
        public string memory { get; set; }

        [Display(Name = "商品顏色")]
        public Nullable<int> color { get; set; }

        [Display(Name = "上傳圖片")]
        public HttpPostedFileBase[] ImageFile { get; set; }

        [Display(Name = "商品規格")]
        [DisplayFormat(ConvertEmptyStringToNull = false, HtmlEncode = true, NullDisplayText = "請輸入商品規格")]
        public string spec { get; set; }

        [Display(Name = "瀏覽次數")]
        public int Browse_time { get; set; }

        [Display(Name = "備註")]
        public string remark { get; set; }

        public List<Category> categoryList { get; set; }
    
        public List<string> colorList { get; set; }
       
        public List<SelectListItem> selectColorList { get; set; }
        public List<Photo> photos { get; set; }

    }
}