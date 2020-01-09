using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpcNtwk.API.Models.Dtos
{
    public class ColumnForCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string Color { get; set; } = "EFC88B";
        public int Width { get; set; } = 3;
    }
}
