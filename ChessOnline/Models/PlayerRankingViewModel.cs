using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ChessOnline.Models
{
    public class PlayerRankingViewModel
    {
        //PLayers et Rankings sont une liste retournant les resultats
        public List<Players>? Players { get; set; }
        public SelectList? Rankings { get; set; }
        //Ranking et SearchString est le nom des field de recherche
        public string? Ranking {  get; set; }
        public string? SearchString { get; set; }
    }
}
