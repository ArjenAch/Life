using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Core.Domain.Exercise
{
    public class WeightSet : Set
    {
        /// <summary>
        /// In kg
        /// </summary>
        
        [Required]
        public int Weight { get; set; }

        [Required]
        public int Reps { get; set; }
    }
}
