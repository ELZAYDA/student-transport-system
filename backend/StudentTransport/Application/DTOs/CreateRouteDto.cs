using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class AuthResponse
    {
        public int DriverId { get; set; }
        public string Name { get; set; } = null!;
        public string StartPoint { get; set; } = null!;
        public string EndPoint { get; set; } = null!;
        public TimeSpan DepartureTime { get; set; }
        public int Capacity { get; set; }
    }
}
