using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Core.Domain.Exercise
{
    public class WeightSet : Set
    {
        /// <summary>
        /// In kg
        /// </summary>
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}
