using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class DanhMuc
    {
        public string Id { get; set; }
        public string TenDanhMuc { get; set; }
        public byte[] Hinh { get; set; }
    }
}
