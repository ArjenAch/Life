using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Core.Domain.Exercises
{
    public class ExerciseInfo : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public ExerciseType ExerciseType { get; set; }
        public string Description { get; set; }
    }
}
