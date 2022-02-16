using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChessOnline.Models
{
    public class Board
    {
        public Square[,]? board { get; set; }
        public int size { get; set; }
    }
}
