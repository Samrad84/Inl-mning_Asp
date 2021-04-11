using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inlämning_Asp.Data;
using Inlämning_Asp.Models;

namespace Inlämning_Asp.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly Inlämning_Asp.Data.EventDbContext _context;

        public JoinEventModel(Inlämning_Asp.Data.EventDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.Include(e => e.Buyers).FirstOrDefaultAsync(m => m.EventId == id);

            if (Event == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyers.FirstOrDefaultAsync();

            if (!Event.Buyers.Contains(buyer))
            {
                Event.Buyers.Add(buyer);
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
