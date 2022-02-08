#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChessOnline.Models;

namespace ChessOnline.Data
{
    public class ChessOnlineContext : DbContext
    {
        public ChessOnlineContext (DbContextOptions<ChessOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<ChessOnline.Models.Players> Players { get; set; }
        public DbSet<ChessOnline.ViewModel.UserInfoViewModel> UserInfo { get; set; }

    }
}
