using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessOnline.Models
{
    public class Players
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        
        [Range(0,int.MaxValue)]
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

        [RegularExpression(@"[a-zA-Z\s]*$")]
        [Display(Name = "Country Of Origin")]
        public string? CountryOfOrigin { get; set; }

    }
}
