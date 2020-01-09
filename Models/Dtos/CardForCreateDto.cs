using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpcNtwk.API.Models.Dtos
{
    public class CardForCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ColumnId { get; set; }
    }
}
