using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChessOnline.Data;
using ChessOnline.Models;
using ChessOnline.ViewModel;
using static ChessOnline.Math.NecessaryMath;

namespace ChessOnline.Controllers
{
    public class BoardController : Controller
    {
        private readonly ChessOnlineContext _context;

        //context provenant de ChessOnlineContext par dependency injection
        public BoardController(ChessOnlineContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var board = new Board
            {
                board = new Square[8,8],
                size = 8
            };
            var controllerBoard = board.board;
            for (int row = 0; row < board.size; row++)
            {

                for (int collumn = 0; collumn < board.size; collumn++)
                {
                    if (isEven(row))
                    {
                        if (isEven(collumn))
                        {
                            controllerBoard[row,collumn] = new Square
                            {
                                XPos = row,
                                YPos = collumn,
                                Color = Color.White
                                
                            };
                        }
                        else
                        {
                            controllerBoard[row,collumn] = new Square
                            {
                                XPos = row,
                                YPos = collumn,
                                Color = Color.Black

                            };
                        }
                    }
                    else
                    {
                        if (isEven(collumn))
                        {
                            controllerBoard[row,collumn] = new Square
                            {
                                XPos = row,
                                YPos = collumn,
                                Color = Color.Black

                            };
                        }
                        else
                        {
                            controllerBoard[row,collumn] = new Square
                            {
                                XPos = row,
                                YPos = collumn,
                                Color = Color.White

                            };
                        }
                    }
                }
            }

            return View(board);
        }
    }
}
