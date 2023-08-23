using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
    public class CharactersController : Controller
    {
        private readonly MoviesData _context;

        public CharactersController(MoviesData context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var moviesData = _context.Character.Include(c => c.Actor).Include(c => c.Movie);
            return View(await moviesData.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Actor)
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.CharacterName == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "ActorID");
            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "MovieID");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,ActorID,CharacterName")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "ActorID", character.ActorID);
            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "MovieID", character.MovieID);
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "ActorID", character.ActorID);
            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "MovieID", character.MovieID);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MovieID,ActorID,CharacterName")] Character character)
        {
            if (id != character.CharacterName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.CharacterName))
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
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "ActorID", character.ActorID);
            ViewData["MovieID"] = new SelectList(_context.Set<Movie>(), "MovieID", "MovieID", character.MovieID);
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Actor)
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.CharacterName == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var character = await _context.Character.FindAsync(id);
            _context.Character.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(string id)
        {
            return _context.Character.Any(e => e.CharacterName == id);
        }
    }
}
