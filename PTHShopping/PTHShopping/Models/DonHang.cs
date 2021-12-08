using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            CtdonHangs = new HashSet<CtdonHang>();
        }

        public string IddonHang { get; set; }
        public string IdkhachHang { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public DateTime? NgayGiaoHang { get; set; }
        public string IdtrangThaiGiaoDich { get; set; }
        public bool? Deleted { get; set; }
        public bool? DaThanhToan { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string IdthanhToan { get; set; }
        public string GhiChu { get; set; }

        public virtual KhachHang IdkhachHangNavigation { get; set; }
        public virtual TrangThaiGiaoDich IdtrangThaiGiaoDichNavigation { get; set; }
        public virtual ICollection<CtdonHang> CtdonHangs { get; set; }
    }
}
