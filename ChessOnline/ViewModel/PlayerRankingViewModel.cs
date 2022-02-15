using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ChessOnline.Models;

namespace ChessOnline.ViewModel
{
    public class PlayerRankingViewModel
    {
        //Players et Rankings sont une liste retournant les resultats
        public List<Players>? Players { get; set; }
        public SelectList? Rankings { get; set; }
        //Ranking et SearchString est le nom des field de recherche
        //Necessite pour fair la recherche dans la base de donnne
        public string? Ranking {  get; set; }
        public string? SearchString { get; set; }
    }
}
