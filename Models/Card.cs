using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpcNtwk.API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; } = DateTime.Now; // When the card was added - default is current date
        public Column Column { get; set; } // The column that the card is in
        public int ColumnId { get; set; } // The id of the column that the card is in


    }
}
