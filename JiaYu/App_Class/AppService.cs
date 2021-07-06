using JiaYu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// 應用程式服務類別
/// </summary>
public static class AppService
{
    /// <summary>
    /// 應用程式名稱
    /// </summary>
    public static string AppName
    {
        get
        {
            object obj_value = WebConfigurationManager.AppSettings["AppName"];
            return (obj_value == null) ? "未定義名稱" : obj_value.ToString();
        }
    }
    public static string AppAdminName
    {
        get
        {
            string admin_value = "嘉裕後台管理";
            return (admin_value == null) ? "未定義名稱" : admin_value;
        }
    }
    public static string AppVersion
    {
        get
        {
            return WebConfigurationManager.AppSettings["AppVersion"];
        }
    }
    public static string AppSiteName
    {
        get
        {
            return WebConfigurationManager.AppSettings["AppSiteName"];
        }
    }
    public static string AppSiteUrl
    {
        get
        {
            return WebConfigurationManager.AppSettings["AppSiteUrl"];
        }
    }
    public static string SearchText
    {
        get { return (HttpContext.Current.Session["SearchText"] == null) ? "" : HttpContext.Current.Session["SearchText"].ToString(); }
        set { HttpContext.Current.Session["SearchText"] = value; }
    }
    public static int PageNo
    {
        get { return (HttpContext.Current.Session["PageNo"] == null) ? 1 : (int)(HttpContext.Current.Session["PageNo"]); }
        set { HttpContext.Current.Session["PageNo"] = value; }
    }

    public static int PageSize
    {
        get { return (HttpContext.Current.Session["PageSize"] == null) ? 1 : (int)(HttpContext.Current.Session["PageSize"]); }
        set { HttpContext.Current.Session["PageSize"] = value; }
    }

    public static string PageType
    {
        get { return (HttpContext.Current.Session["PageType"] == null) ? "" : HttpContext.Current.Session["PageType"].ToString(); }
        set { HttpContext.Current.Session["PageType"] = value; }
    }

    /// <summary>
    /// 除錯模式
    /// </summary>
    public static bool DebugMode
    {
        get
        {
            object obj_value = WebConfigurationManager.AppSettings["DebugMode"];
            string str_value = (obj_value == null) ? "0" : obj_value.ToString();
            return (str_value == "1");
        }
    }
    public static List<Category> GetModuleList()
    {
        using (JiaYuEntities db = new JiaYuEntities())
        {
            return db.Category
                .Where(m => m.super_id == null)
                .OrderBy(m => m.sort_no)
                .OrderBy(m => m.cate_id)
                .ToList();
        }
    }
    public static List<Category> GetProgramlist(string parentID)
    {
        using (JiaYuEntities db = new JiaYuEntities())
        {
            return db.Category
                 .Where(m => m.super_id == parentID)
                 .OrderBy(m => m.sort_no)
                 .OrderBy(m => m.cate_id)
                 .ToList();

        }
    }
}
