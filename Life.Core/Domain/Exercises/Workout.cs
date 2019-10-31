using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Core.Domain.Exercises
{
    public class Workout
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
