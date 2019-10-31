using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Application.Services.Exercises.DTO
{
    public class SetDTO
    {
        public string SetDescription { get; set; }
        public int Duration { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}
