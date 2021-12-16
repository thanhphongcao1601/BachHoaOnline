using PTHShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTHShopping.Helper
{
    public class RandomID
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private readonly PTHShoppingContext _context;

        public RandomID(PTHShoppingContext context)
        {
            _context = context;
        }

        public string RandomIDKhachHang()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string rs = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            var id = _context.KhachHangs.Where(x => rs == x.IdkhachHang).ToList();
            if (id != null)
            {
                RandomIDKhachHang();
            }
            return rs;
        }
    }
}
