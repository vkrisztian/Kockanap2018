using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
 public   class Hero
    {
        public Player Player { get; set; }
        public bool IsReverse { get; set; }
        public double DamageCaused { get; set; }
        public double DistanceCovered { get; set; }
        public double TotalHP { get; set; }
    }
}
