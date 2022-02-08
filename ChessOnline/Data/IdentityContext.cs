#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChessOnline.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChessOnline.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
        public DbSet<ChessOnline.Models.UserInfo> UserInfo { get; set; }
        //public DbSet<ChessOnline.Models.User> User { get; set; }


    }
}
