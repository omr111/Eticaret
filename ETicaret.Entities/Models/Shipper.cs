using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new List<Order>();
        }

        public int id { get; set; }
        public string CompanyName { get; set; }
        public string phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
