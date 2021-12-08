using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class Trang
    {
        public string Idtrang { get; set; }
        public string TenTrang { get; set; }
        public string NoiDung { get; set; }
        public string Thumb { get; set; }
        public bool? Published { get; set; }
        public string TieuDe { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public string KiHieu { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? Ordering { get; set; }
    }
}
