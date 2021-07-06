using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JiaYu.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
   
        private class ProductMetaData
        {
           
            [Key]
            [Display(Name = "商品編號")]
            [Required(ErrorMessage = "商品編號不可空白")]
            public string pro_id { get; set; }

            [Display(Name = "商品名稱")]
            [DisplayFormat(ConvertEmptyStringToNull = false, HtmlEncode = true, NullDisplayText = "請輸入商品名稱")]
            public string pname { get; set; }

            [Display(Name = "分類ID")]
            [Required(ErrorMessage = "分類ID不可空白")]
            public string categoryid { get; set; }

            [Display(Name = "廠商編號")]
            public string ven_id { get; set; }
            [Display(Name = "銷售單價")]
            [Required(ErrorMessage = "銷售單價不可空白")]
            public int price_sale { get; set; }

            [Display(Name = "記憶體容量")]
            [Required(ErrorMessage = "記憶體容量不可空白")]
            public string memory { get; set; }

            [Display(Name = "顏色代號")]
            public Nullable<int> color { get; set; }

            [Display(Name = "商品規格")]
            [DisplayFormat(ConvertEmptyStringToNull = false, HtmlEncode = true, NullDisplayText = "請輸入商品規格")]
            public string spec { get; set; }

            [Display(Name = "瀏覽次數")]
            public int Browse_time { get; set; }

            [Display(Name = "備註")]
            public string remark { get; set; }

            [NotMapped]
            [Display(Name = "首頁")]
            public bool Is_top { get; set; }
            [NotMapped]
            [Display(Name = "熱門")]
            public bool Is_hot { get; set; }
            [NotMapped]
            [Display(Name = "上架")]
            public bool is_sales { get; set; }

        }
    }
}