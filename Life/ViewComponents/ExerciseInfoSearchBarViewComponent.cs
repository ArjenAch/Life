using Life.Application.Services.Interfaces.Exercise;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life.ViewComponents
{
    public class ExerciseInfoSearchBarViewComponent : ViewComponent
    {
        private readonly IExerciseInfoService _exerciseInfoService;

        public ExerciseInfoSearchBarViewComponent(IExerciseInfoService exerciseInfoService)
        {
            _exerciseInfoService = exerciseInfoService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var exerciseInfoList = await _exerciseInfoService.GetAllAsync();

            return View(exerciseInfoList.ToList());
        }
    }
}
