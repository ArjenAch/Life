using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Services.Goals.DTO
{
    public class ThisWeeksExerciseDTO : GoalDTO
    {
        public int ToGo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Went { get; set; }
    }
}
