using JiaYu.Models;
using JiaYu.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevStudio.Securitys;


/// <summary>
/// 使用者資訊類別
/// </summary>
public static class UserAccount
{
    /// <summary>
    /// 登入使用者角色
    /// </summary>
    public static EnumList.LoginRole Role { get; set; } = EnumList.LoginRole.Guest;
    /// <summary>
    /// 登入使用者角色名稱
    /// </summary>
    public static string RoleName { get { return EnumList.GetRoleName(Role); } }
    public static AppEnum.enUserRole RoleNo { get; set; } = AppEnum.enUserRole.Guest;
    /// <summary>
    /// 使用者帳號
    /// </summary>
    public static string user_id { get; set; } = "";
    /// <summary>
    /// 使用者名稱
    /// </summary>
    public static string m_name { get; set; } = "";
    /// <summary>
    /// 使用者電子信箱
    /// </summary>
    public static string email { get; set; } = "";
    /// <summary>
    /// 使用者是否已登入
    /// </summary>
    public static bool IsLogin { get; set; } = false;

    public static string ErrorMessage { get; set; } = "";

    public static bool Login(LoginViewModel model)
    {
        using (JiaYuEntities db = new JiaYuEntities())
        {
            using (Cryptographys cryp = new Cryptographys()) {
                Logout();
                string str_password = cryp.SHA256Encode(model.passwd);
                var admin = db.Manage.Where(m => m.user_id == model.user_id)
                                 .Where(m => m.passwd == str_password).FirstOrDefault();
                if (admin != null)
                {
                    Role = EnumList.LoginRole.Admin;
                    Login(admin.user_id, admin.email, admin.m_name);
                }
                else
                {
                    var data = db.Member.Where(m => m.user_id == model.user_id).Where(m => m.passwd == str_password).FirstOrDefault();
                    if (data == null) { ErrorMessage = "會員帳號不存在!!!"; return false; }
                    Role = EnumList.LoginRole.User;
                    Login(data.user_id, data.email, data.m_name);
                }
            return true;

            }
        }
    }
    public static void Login(string memberID, string memberEmail, string memberName)
    {
        user_id = memberID;
        email = memberEmail;
        m_name = memberName;
        IsLogin = true;
        Cart.LoginCart();
       
    }


    public static void Logout()
    {
        IsLogin = false;
        Role = EnumList.LoginRole.Guest;
        user_id = "";
        m_name = "";
        email = "";
    }
    public static int UserStatus
    {
        get
        {
            int int_value = 0;
            if (HttpContext.Current.Session["UserStatus"] != null)
            {
                string str_value = HttpContext.Current.Session["UserStatus"].ToString();
                if (!int.TryParse(str_value, out int_value)) int_value = 0;
            }
            return int_value;
        }
        set
        { HttpContext.Current.Session["UserStatus"] = value; }
    }
    public static int UserCode
    {
        get
        {
            int int_value = -1;
            if (HttpContext.Current.Session["UserCode"] != null)
            {
                string str_value = HttpContext.Current.Session["UserCode"].ToString();
                if (!int.TryParse(str_value, out int_value)) int_value = -1;
            }
            return int_value;
        }
        set
        { HttpContext.Current.Session["UserCode"] = value; }
    }

}
