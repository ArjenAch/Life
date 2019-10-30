using Life.Application.Services.Exercise.DTO;
using Life.Core.Domain.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Tests.ServiceMocks
{
    public class ExerciseInfoServiceMocks
    {
        private List<ExerciseInfoDTO> _exercises;
        public ExerciseInfoServiceMocks ()
        {
            _exercises = new List<ExerciseInfoDTO>()
            {
                new ExerciseInfoDTO()
                {
                    Id = 0,
                    ExerciseType = ExerciseType.Strength,
                    Title = "Bench press",
                    Description = "pressing a barbell"
                },
                new ExerciseInfoDTO()
                {
                    Id = 1,
                    ExerciseType = ExerciseType.Cardio,
                    Title = "Cycling",
                    Description = "Cycling on a bike"
                },
                new ExerciseInfoDTO()
                {
                    Id = 2,
                    ExerciseType = ExerciseType.Flexibility,
                    Title = "Yoga",
                    Description = "Doing various poses"
                }
            };
        }


        public List<ExerciseInfoDTO> GetExerciseInfoList()
        {
            return _exercises;

        }

        public ExerciseInfoDTO GetByIdAsync(int id)
        {
            return _exercises.FirstOrDefault(exercise => exercise.Id == id);
        }
    }
}
