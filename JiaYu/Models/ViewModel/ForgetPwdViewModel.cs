using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JiaYu.Models.ViewModel
{
    public class ForgetPwdViewModel
    {
       
        [Display(Name = "電子信箱")]
        [Required(ErrorMessage = "電子信箱不可空白!!")]
        [EmailAddress(ErrorMessage = "電子信箱格式錯誤!!")]
        public string email { get; set; }   
    }
}