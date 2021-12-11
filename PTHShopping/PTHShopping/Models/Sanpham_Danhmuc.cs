using PagedList.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Models
{
    public class Sanpham_Danhmuc
    {
        public List<SanPham> ListSanpham { get; set; }
        public List<Category> ListDanhmuc { get; set; }
        public PagedList<Trang> ListTintuc { get; set; }
    }
}
