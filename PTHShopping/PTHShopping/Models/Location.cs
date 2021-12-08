using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class Location
    {
        public Location()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        public string IdviTri { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string Slug { get; set; }
        public string NameWithType { get; set; }
        public string PathWithType { get; set; }
        public int? ParentCode { get; set; }
        public int? Levels { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
