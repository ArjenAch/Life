using Life.Core.Domain.Exercise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Application.Services.Exercise.DTO
{
    public class ExerciseInfoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public ExerciseType ExerciseType { get; set; }
        public string Description { get; set; }
    }
}
