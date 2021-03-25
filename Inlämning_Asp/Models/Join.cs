using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_Asp.Models
{
    public class Join
    {

        public int JoinId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
