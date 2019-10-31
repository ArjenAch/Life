using Life.Application.Services.Exercises.DTO;
using Life.Application.Services.Interfaces.Exercises;
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

        public IViewComponentResult Invoke(ExerciseDTO exerciseInfo)
        {
            return View(exerciseInfo);
        }

    }
}

