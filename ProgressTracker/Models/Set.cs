using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Models
{
    internal class Set
    {
        public int Reps { get; set; }
        public int Weight { get; set; }

        public Set(int reps, int weight)
        {
            Reps = reps;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Reps} x {Weight}";
        }
    }
}
