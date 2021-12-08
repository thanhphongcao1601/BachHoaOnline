using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class CtdonHang
    {
        public string IdctdonHang { get; set; }
        public string IddonHang { get; set; }
        public string IdsanPham { get; set; }
        public int? SoDonHang { get; set; }
        public int? SoLuong { get; set; }
        public double? KhuyenMai { get; set; }
        public double? Tong { get; set; }
        public DateTime? NgayGiaoHang { get; set; }

        public virtual DonHang IddonHangNavigation { get; set; }
        public virtual SanPham IdsanPhamNavigation { get; set; }
    }
}
