using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain
{
    public class UserRole
    {
        UserRole() { }
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
