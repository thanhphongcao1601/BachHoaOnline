using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class Category
    {
        public Category()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string CatId { get; set; }
        public string CatName { get; set; }
        public string MoTa { get; set; }
        public string ParrentId { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool? Published { get; set; }
        public string Thumb { get; set; }
        public string TieuDe { get; set; }
        public string KyHieu { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public string Cover { get; set; }
        public string SchemaMarkup { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
