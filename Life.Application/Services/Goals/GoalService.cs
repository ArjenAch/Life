using Life.Application.Services.Goals.DTO;
using Life.Application.Services.Interfaces.Goals;
using Life.Core.Domain.Goals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Services.Goals
{
    public class GoalService : IGoalService
    {
        public GoalDTO GetGoalModel(GoalType goal)
        {
            if (goal == GoalType.ThisWeeksExercise)
            {
                return new ThisWeeksExerciseDTO()
                {
                    ToGo = 3,
                    Went = 2,
                    Title = "This weeks Exercise",
                    Description = "Going to the gym",
                    ViewName = "ThisWeeksExercise"
                };
            }

            return null;
        }
    }
}
