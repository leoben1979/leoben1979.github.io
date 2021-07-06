using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using JiaYu.Models;

public class ListItemViewModel : BaseClass
{
  
    /// <summary>
    /// 性別列表
    /// </summary>
    public List<SelectListItem> GenderList
    {
        get
        {
            List<SelectListItem> list_value = new List<SelectListItem>();
            list_value.Add(new SelectListItem() { Text = "男", Value = "M" });
            list_value.Add(new SelectListItem() { Text = "女", Value = "F" });
            return list_value;
        }
    }

}