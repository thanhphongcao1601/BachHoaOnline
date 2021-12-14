using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string IdkhachHang { get; set; }
        public string HoTen { get; set; }
        public DateTime? SinhNhat { get; set; }
        public string Avatar { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Idvitri { get; set; }
        public string Quan { get; set; }
        public string Phuong { get; set; }
        public DateTime? NgayTao { get; set; }
        public string MatKhau { get; set; }
        public string Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? Active { get; set; }
        public bool? Giotinh { get; set; }

        public virtual Location IdvitriNavigation { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
