using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Dal.Concrete.EntityFramework
{
    public class ProductBrand
    {
        public string productName { get; set; }
        public decimal Price { get; set; }
        public int brandId { get; set; }
        public string brandName { get; set; }
        public int stok { get; set; }
    }
}