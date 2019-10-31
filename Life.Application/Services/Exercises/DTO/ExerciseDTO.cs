using Life.Application.Services.Exercises.Binder;
using Life.Core.Domain.Exercises;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Application.Services.Exercises.DTO
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        [Required]
        public int InfoId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public ExerciseType ExerciseType { get; set; }
        public string Description { get; set; }

        [ModelBinder(BinderType = typeof(SetsBinder))]
        public List<SetDTO> Sets { get; set; }

        public ExerciseDTO ()
        {
            Sets = new List<SetDTO>();
        }
    }
}
