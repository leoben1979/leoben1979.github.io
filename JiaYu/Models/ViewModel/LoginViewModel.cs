using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JiaYu.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "登入帳號")]
        [Required(ErrorMessage = "登入帳號不可空白!!")]
        [StringLength(12, ErrorMessage = "登入帳號長度不可超過12個字!!")]
        public string user_id { set; get; }

        [Display(Name = "登入密碼")]
        [Required(ErrorMessage = "登入密碼不可空白!!")]
        [DataType(DataType.Password)]
        public string passwd { set; get; }
    }
}