using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_Asp.Models
{
    public class Event
    {

        public int EventId { get; set; }

        public string Url { get; set; }

        public ICollection<Join> joins { get; set; }
    }
}
