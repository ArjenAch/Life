using Life.Application.Services.Interfaces.Goals;
using Life.Core.Domain.Goals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life.ViewComponents
{
    public class GoalViewComponent : ViewComponent
    {
        private readonly IGoalService _goalService;

        public GoalViewComponent(IGoalService goalService)
        {
            this._goalService = goalService;
        }
        public IViewComponentResult Invoke(GoalType goal)
        {
            var model = _goalService.GetGoalModel(goal);
            if(model !=null)
            {
                return View(model.ViewName, model);
            }

            return View();
        }
    }
}
