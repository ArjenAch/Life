using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Core.Domain.Exercises
{
    public class WeightSet : Set
    {
        /// <summary>
        /// In kg
        /// </summary>
        
        [Required]
        [Range(0, 200000)]
        public int Weight { get; set; }

        [Required]
        [Range(1, 100)]
        public int Reps { get; set; }
    }
}
