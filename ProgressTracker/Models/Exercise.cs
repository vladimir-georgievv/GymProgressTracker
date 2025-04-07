using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Models
{
    internal class Exercise
    {
        public string Name { get; set; }
        public List<Set> Sets { get; set; } = new List<Set>();
        public Exercise(string name)
        {
            Name = name;
        }
    }
}
