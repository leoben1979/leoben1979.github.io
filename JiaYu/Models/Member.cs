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
    
    public partial class Member
    {
        public string user_id { get; set; }
        public string passwd { get; set; }
        public string email { get; set; }
        public bool verify { get; set; }
        public System.DateTime reg_date { get; set; }
        public string id_number { get; set; }
        public string m_name { get; set; }
        public string sex { get; set; }
        public System.DateTime birthday { get; set; }
        public string telephone { get; set; }
        public string cellphone { get; set; }
        public string address { get; set; }
        public string remark { get; set; }
    }
}
