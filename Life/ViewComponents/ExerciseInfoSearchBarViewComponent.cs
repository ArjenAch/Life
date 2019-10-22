using Life.Application.Services.Exercise.DTO;
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

        public IViewComponentResult Invoke(ExerciseInfoDTO exerciseInfo)
        {
            return View(exerciseInfo);
        }

    }
}

