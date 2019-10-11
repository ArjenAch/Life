using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Core.Domain.Exercise
{
    public class DurationSet : Set
    {
        public string Title { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>
        public int Duration { get; set; }
    }
}
