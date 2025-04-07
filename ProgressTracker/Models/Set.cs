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
        public DateTime Date { get; set; }

        public Set(int reps, int weight, DateTime date)
        {
            Reps = reps;
            Weight = weight;
            Date = date;
        }
        public override string ToString()
        {
            return $"{Reps} x {Weight}";
        }
    }
}
