using Life.Application.Services.Exercises.DTO;
using Life.Application.Services.Interfaces.Exercises;
using Life.Core.Domain.Exercises;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life.ViewComponents
{
    public class ExerciseItemsMenuViewComponent : ViewComponent
    {
        private IExerciseService _exerciseService;
        public ExerciseItemsMenuViewComponent(IExerciseService service)
        {
            _exerciseService = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var exercises = await _exerciseService.GetAllAsync();
            var typeLists = exercises.GroupBy(exercise => exercise.ExerciseType);
            
            return View(typeLists);
        }
    }
}
