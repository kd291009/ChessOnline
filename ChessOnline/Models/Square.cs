using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChessOnline.Models
{
    public class Square
    {
        [Range(0,7)]
        public int XPos { get; set; }
        [Range(0, 7)]
        public int YPos { get; set; }
        public Color Color { get; set; }

        
    }
}
