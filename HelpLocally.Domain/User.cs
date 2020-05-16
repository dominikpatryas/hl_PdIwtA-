using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain
{
    public class User
    {
        public User(string login) { Login = login; }
        User() { }
        public int Id { get; private set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
