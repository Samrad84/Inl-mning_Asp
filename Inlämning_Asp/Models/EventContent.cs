using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Inlämning_Asp.Models
{
    public class EventContent  : DbContext
    {
        public EventContent(DbContextOptions<EventContent> options)
            : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Join> Joins { get; set; }
    }
}
