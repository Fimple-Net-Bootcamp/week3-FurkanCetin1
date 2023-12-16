using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week03.Models
{
    public class HealthStatus
    {
        public int Id { get; set; }
        public DateTime? CheckupDate { get; set; }
        public int? MyProperty { get; set; }
        public int? Weight { get; set; }
    }
}