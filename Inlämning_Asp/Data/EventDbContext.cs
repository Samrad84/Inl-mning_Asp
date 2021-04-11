using Inlämning_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Inlämning_Asp.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Join> Joins { get; set; }

        public DbSet<Buyer> Buyers { get; set; }




        public void ResetAndSeed()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Buyer[] buyers = new Buyer[] {
                new Buyer()
                {
                    Name = "Ian Holmes",
                    PhoneNumber = "+1 203 42 564",
                    Email = "ian.holmes@gmail.com",
                },
            };

         

            Event[] events = new Event[] {
                new Event(){
                    EventName="Lady gaga",
                    Description="CONCERT - VARIETE INTERNATIONALE",
                    Place="STADE DE FRANCE",
                    Date=DateTime.Now.AddDays(34),
                    Photo= " https://static.ticketmaster.fr/static/images/vignettes/n_lady-gaga.gif ",
                    Url= "https://www.ticketmaster.fr/fr/manifestation/lady-gaga-billet/idmanif/489284/idtier/18864121",

                },
                new Event(){
                      EventName="Lady gaga",
                    Description="CONCERT - VARIETE INTERNATIONALE",
                    Place="STADE DE FRANCE",
                    Date=DateTime.Now.AddDays(34),
                    Photo= "https://static.ticketmaster.fr/static/images/vignettes/n_lady-gaga.gif ",
                    Url= "https://www.ticketmaster.fr/fr/manifestation/lady-gaga-billet/idmanif/489284/idtier/18864121",

                },
            };

            Join[] joins = new Join[] {
                new Join(){
                    Event = events [0],
                    Buyer = buyers[0],
                },
            };

            AddRange(buyers);
            AddRange(joins);
            AddRange(events);

            SaveChanges();
        }
    }
}
