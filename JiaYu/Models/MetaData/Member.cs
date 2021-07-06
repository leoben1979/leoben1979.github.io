using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JiaYu.Models
{
    [MetadataType(typeof(MemberMetaData))]

    public partial class Member
    {
        [Display(Name = "性別")]
        [NotMapped]
        public string name_gender
        {
            get
            {
                using (ListItemViewModel model = new ListItemViewModel())
                {
                    var data = model.GenderList.Where(m => m.Value == sex).FirstOrDefault();
                    return (data == null) ? "" : data.Text;
                }
            }
        }
        private class MemberMetaData
        {
            [Key]
            [Display(Name = "登入帳號")]
            [Required(ErrorMessage = "登入帳號不可空白!!")]
            [StringLength(12, ErrorMessage = "登入帳號長度不可超過12個字!!")]
            public string user_id { get; set; }
            [Display(Name = "密碼")]
            [Required(ErrorMessage = "登入密碼不可空白!!")]
            [DataType(DataType.Password)]
            public string passwd { get; set; }
            [Display(Name = "電子信箱")]
            [Required(ErrorMessage = "電子信箱不可空白!!")]
            [EmailAddress(ErrorMessage = "電子信箱格式錯誤!!")]
            public string email { get; set; }
            [Display(Name = "是否啟用")]
            public bool verify { get; set; }
            [Display(Name = "註冊日期")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
            public System.DateTime reg_date { get; set; }
            [Display(Name = "身份證號")]
            [Required(ErrorMessage = "身份證號不可空白!!")]
            [StringLength(10, ErrorMessage = "請輸入長度 10 的文數字!!", MinimumLength = 5)]
            public string id_number { get; set; }
            [Display(Name = "姓名")]
            [Required(ErrorMessage = "姓名不可空白!!")]
            public string m_name { get; set; }
            [Display(Name = "性別")]
            public string sex { get; set; }
            [Display(Name = "出生日期")]
            [Required(ErrorMessage = "出生日期不可空白!!")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
            public System.DateTime birthday { get; set; }
            [Display(Name = "電話")]
            public string telephone { get; set; }
            [Display(Name = "行動電話")]
            [Required(ErrorMessage = "行動電話不可空白!!")]
            public string cellphone { get; set; }
            [Display(Name = "聯絡地址")]
            [Required(ErrorMessage = "聯絡地址不可空白!!")]
            public string address { get; set; }
           

        }
    }
}