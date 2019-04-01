using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Members = new List<Member>();
        }

        public int id { get; set; }
        public string RolName { get; set; }
        public string Aciklama { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
