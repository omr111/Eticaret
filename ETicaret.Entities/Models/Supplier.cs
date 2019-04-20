using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            this.Cities = new List<City>();
        }

        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public Nullable<int> CityID { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string HomePage { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
