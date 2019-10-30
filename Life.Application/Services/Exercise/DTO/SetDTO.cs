using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Life.Application.Services.Exercise.DTO
{
    public class SetDTO
    {
        public string Index { get; set; }
        public string SetDescription { get; set; }
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }
        [Range(0, 200000)]
        public int Weight { get; set; }
        [Range(1, 100)]
        public int Reps { get; set; }
    }
}
