using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Core.Domain.Exercises
{
    public class DurationSet : Set
    {
        public string Description { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>

        [Required]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }
    }
}
