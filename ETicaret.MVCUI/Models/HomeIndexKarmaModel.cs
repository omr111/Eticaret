using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaret.Bll.Concrete;
using ETicaret.Entities.Models;
using PagedList;

namespace ETicaret.MVCUI.Models
{
    public class HomeIndexKarmaModel
    {
       
       
        public List<Category> Categories { get; set; }
        public int? PageNo { get; set; }

        public IPagedList<Product> LatestAddedProducts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}