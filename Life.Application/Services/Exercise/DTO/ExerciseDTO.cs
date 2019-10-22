using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Services.Exercise.DTO
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public ExerciseInfoDTO ExerciseInfo{get;set;}

        public List<SetDTO> Sets { get; set; }
    }
}
