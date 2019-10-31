using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Core.Domain.Exercise
{
    public class DurationSet : Set
    {
        public string Description { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>

        [Required]
        public int Duration { get; set; }
    }
}
