using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_Asp.Models
{
    public class Event
    {

        public int EventId { get; set; }

        public string EventName { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public DateTime Date { get; set; }

       public string Url { get; set; }

        public List<Buyer> Buyers { get; set; }
    }
}
