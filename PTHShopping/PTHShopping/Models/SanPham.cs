using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CtdonHangs = new HashSet<CtdonHang>();
        }

        public string IdsanPham { get; set; }
        public string TenSanPham { get; set; }
        public string ShortDesc { get; set; }
        public string MoTa { get; set; }
        public string CatId { get; set; }
        public double? Gia { get; set; }
        public double? KhuyenMai { get; set; }
        public string Thumb { get; set; }
        public string Video { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool? BestSellers { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? Active { get; set; }
        public string Tags { get; set; }
        public string TieuDe { get; set; }
        public int? Slban { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int? UnitsInStock { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<CtdonHang> CtdonHangs { get; set; }
    }
}
