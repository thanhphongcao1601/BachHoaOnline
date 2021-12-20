using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Models
{
    public class CartItem
    {
        public String MaSp { get; set; }
        public string TenSp { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * DonGia;
        public string DiaChi { get; set; }
    }
}
