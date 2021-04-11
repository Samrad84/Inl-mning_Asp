using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_Asp.Models;

namespace Inlämning_Asp.Models
{
    public class Join
    {

        public int JoinId { get; set; }
        public Event Event { get; set; }

        public Buyer Buyer { get; set; }

    }
}
