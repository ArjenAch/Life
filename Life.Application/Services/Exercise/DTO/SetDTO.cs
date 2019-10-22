using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Application.Services.Exercise.DTO
{
    public class SetDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}
