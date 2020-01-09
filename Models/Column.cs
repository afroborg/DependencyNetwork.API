using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpcNtwk.API.Models
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; } // Position of column in the list
        public string Color { get; set; } // Color of column
        public int Width { get; set; } // Span of column in list (full width = 12)
        public ICollection<Card> Cards { get; set; }
    }
}
