using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;
using PagedList;

namespace ETicaret.MVCUI.Models
{
    public class FilterPage
    {
        //public List<Product> Products { get; set; }
        public IPagedList<Product> Products { get; set; }
        public List<ProductBrand> BrandsOfProduct { get; set; }
       
    }
}