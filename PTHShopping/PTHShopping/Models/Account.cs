using System;
using System.Collections.Generic;

#nullable disable

namespace PTHShopping.Models
{
    public partial class Account
    {
        public string AccountId { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool? Active { get; set; }
        public string HoTen { get; set; }
        public string RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual Role Role { get; set; }
    }
}
