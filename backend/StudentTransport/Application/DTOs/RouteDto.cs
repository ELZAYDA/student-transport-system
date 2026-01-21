using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
    }
}
