using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class City
    {
        public int id { get; set; }
        public string CityName { get; set; }
        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
