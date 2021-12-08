using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class TrangThaiGiaoDich
    {
        public TrangThaiGiaoDich()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string IdtrangThaiGiaoDich { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
