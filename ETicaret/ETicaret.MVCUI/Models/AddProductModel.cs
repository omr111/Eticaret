using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaret.Entities.Models;

namespace ETicaret.MVCUI.Models
{
    public class AddProductModel
    {
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }

    }
}