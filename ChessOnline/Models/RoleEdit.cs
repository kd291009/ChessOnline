using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ChessOnline.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<UserInfo> Members { get; set; }
        public IEnumerable<UserInfo> NonMembers { get; set; }
    }
}
