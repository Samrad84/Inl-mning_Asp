using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inlämning_Asp.Models;

namespace Inlämning_Asp.Controllers
{
    public class JoinsController : Controller
    {
        private readonly EventContent _context;

        public JoinsController(EventContent context)
        {
            _context = context;
        }

        // GET: Joins
        public async Task<IActionResult> Index()
        {
            var eventContent = _context.Joins.Include(@ => @.Evenet);
            return View(await eventContent.ToListAsync());
        }

        // GET: Joins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @join = await _context.Joins
                .Include(@ => @.Evenet)
                .FirstOrDefaultAsync(m => m.JoinId == id);
            if (@join == null)
            {
                return NotFound();
            }

            return View(@join);
        }

        // GET: Joins/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            return View();
        }

        // POST: Joins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JoinId,Title,Content,EventId")] Join @join)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@join);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", @join.EventId);
            return View(@join);
        }

        // GET: Joins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @join = await _context.Joins.FindAsync(id);
            if (@join == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", @join.EventId);
            return View(@join);
        }

        // POST: Joins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JoinId,Title,Content,EventId")] Join @join)
        {
            if (id != @join.JoinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@join);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoinExists(@join.JoinId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", @join.EventId);
            return View(@join);
        }

        // GET: Joins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @join = await _context.Joins
                .Include(@ => @.Evenet)
                .FirstOrDefaultAsync(m => m.JoinId == id);
            if (@join == null)
            {
                return NotFound();
            }

            return View(@join);
        }

        // POST: Joins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @join = await _context.Joins.FindAsync(id);
            _context.Joins.Remove(@join);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoinExists(int id)
        {
            return _context.Joins.Any(e => e.JoinId == id);
        }
    }
}
