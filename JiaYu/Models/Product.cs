//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JiaYu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public string pro_id { get; set; }
        public string pname { get; set; }
        public string categoryid { get; set; }
        public string ven_id { get; set; }
        public Nullable<bool> Is_top { get; set; }
        public Nullable<bool> Is_hot { get; set; }
        public Nullable<bool> is_sales { get; set; }
        public int price_sale { get; set; }
        public string memory { get; set; }
        public Nullable<int> color { get; set; }
        public string spec { get; set; }
        public int Browse_time { get; set; }
        public string remark { get; set; }
    }
}