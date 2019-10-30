using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Core.Domain.Exercise
{
    public class Exercise
    {
        public int Id { get; set; }
        public ExerciseInfo ExerciseInfo { get; set; }
        public List<Set> Sets { get; set; }

    }
}
