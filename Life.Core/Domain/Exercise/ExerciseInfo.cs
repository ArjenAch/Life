using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Core.Domain.Exercise
{
    public class ExerciseInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ExerciseType Type { get; set; }
        public string Description { get; set; }
    }
}
