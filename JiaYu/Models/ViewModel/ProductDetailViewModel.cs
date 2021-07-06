using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaYu.Models.ViewModel
{
    public class ProductDetailViewModel
    {
        public string pro_id { get; set; }
        public string pname { get; set; }
        public int price_sale { get; set; }
        public string memory { get; set; }
        public string remark { get; set; }
        public string spec { get; set; }
        public string color_no { get; set; }
        public int qty { get; set; }

        public List<SelectListItem> selectColorList { get; set; }
        public List<Photo> photos { get; set; }
    }
}