using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life.Application.Services.Exercise.DTO;
using Life.Application.Services.Interfaces.Exercise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Life.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesInfoController : ControllerBase
    {
        private readonly IExerciseInfoService _exerciseInfoService;

        public ExercisesInfoController(IExerciseInfoService exerciseInfoService)
        {
            _exerciseInfoService = exerciseInfoService;
        }

        public async Task<List<ExerciseInfoDTO>> GetAllAsync()
        {
            return (await _exerciseInfoService.GetAllAsync()).ToList();
        }
    }
}