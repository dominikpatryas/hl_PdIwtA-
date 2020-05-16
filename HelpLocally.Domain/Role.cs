using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLocally.Domain
{
    public class Role
    {
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
