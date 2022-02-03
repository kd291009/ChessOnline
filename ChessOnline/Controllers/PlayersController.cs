#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChessOnline.Data;
using ChessOnline.Models;

namespace ChessOnline.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ChessOnlineContext _context;

        //context provenant de ChessOnlineContext par dependency injection
        public PlayersController(ChessOnlineContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index(int ranking, string searchString)
        {
            //LINQ fait la recherche dans notre base de données
            IQueryable<int> rankingQuery = from m in _context.Players
                                           orderby m.Ranking
                                           select m.Ranking;
            var players = from p in _context.Players
                          select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Name!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(ranking.ToString()))
            {
                players = players.Where(x => x.Ranking >= ranking);
            }

            var playerRankingVM = new PlayerRankingViewModel
            {
                //var de PlayerRankingViewModel
                Rankings = new SelectList(await rankingQuery.Distinct().ToListAsync()),
                Players = await players.ToListAsync()
            };

            return View(playerRankingVM);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players
                .FirstOrDefaultAsync(m => m.Id == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GamesPlayed,GamesWon,GamesLost,GamesTied,WinPercentage,Ranking,countryOfOrigin")] Players players)
        {
            if (ModelState.IsValid)
            {
                _context.Add(players);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(players);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players.FindAsync(id);
            if (players == null)
            {
                return NotFound();
            }
            return View(players);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //values in the Bind attribute should only be ones we want to change
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GamesPlayed,GamesWon,GamesLost,GamesTied,WinPercentage,Ranking,countryOfOrigin")] Players players)
        {
            if (id != players.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(players);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayersExists(players.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(players);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players
                .FirstOrDefaultAsync(m => m.Id == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var players = await _context.Players.FindAsync(id);
            _context.Players.Remove(players);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayersExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
