﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inlämning_Asp.Data;
using Inlämning_Asp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Inlämning_Asp.Pages
  
{

    [Authorize(Roles = "superadmin,admin,employee")]
    public class EventsModel : PageModel
    {
        private readonly EventDbContext _context;

        public EventsModel(EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }
    }
}
