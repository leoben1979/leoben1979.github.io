using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JiaYu.Models.ViewModel
{
    public class ProductListViewModel
    {
        public Product product { get; set; }
        public Category category { get; set; }
       
    }
}