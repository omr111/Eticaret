using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class MemberPicture
    {
        public int id { get; set; }
        public int MemberID { get; set; }
        public string PicturePath { get; set; }
        public virtual Member Member { get; set; }
    }
}
