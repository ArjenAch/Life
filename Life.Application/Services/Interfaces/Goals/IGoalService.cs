using Life.Application.Services.Goals.DTO;
using Life.Core.Domain.Goals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Services.Interfaces.Goals
{
    public interface IGoalService
    {
        GoalDTO GetGoalModel(GoalType goal);
    }
}
