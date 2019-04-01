using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Region
    {
        public Region()
        {
            this.Cities = new List<City>();
        }

        public int id { get; set; }
        public string RegionName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
