using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace ChessOnline.Models
{
    public class UserInfo : IdentityUser
    {
        public Country Country { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Games Played")]
        public int GamesPlayed { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Games Won")]
        public int GamesWon { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Games Lost")]
        public int GamesLost { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Games Tied")]
        public int GamesTied { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Win %")]
        public int WinPercentage { get; set; }

        public int Ranking { get; set; }
    }
}
