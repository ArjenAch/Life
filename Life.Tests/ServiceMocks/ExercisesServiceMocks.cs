using Life.Application.Services.Exercises.DTO;
using Life.Core.Domain.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Tests.ServiceMocks
{
    public class ExercisesServiceMocks
    {
        private List<ExerciseDTO> _exercises;
        private List<ExerciseInfoDTO> _exercisesInfo;
        public ExercisesServiceMocks()
        {
            _exercises = new List<ExerciseDTO>()
            {
                new ExerciseDTO()
                {
                    Id = 1,
                    InfoId = 1,
                    ExerciseType = ExerciseType.Strength,
                    Title = "Bench press",
                    Description = "push the bar away from the chest",
                    Sets = new List<SetDTO> ()
                    {
                        new SetDTO ()
                        {
                            Reps = 10,
                            Weight = 100
                        },
                        new SetDTO ()
                        {
                            Reps = 10,
                            Weight = 110
                        },
                        new SetDTO ()
                        {
                            Reps = 10,
                            Weight = 120
                        }
                    }
                },
                new ExerciseDTO()
                {
                    Id = 2,
                    InfoId = 2,
                    ExerciseType = ExerciseType.Cardio,
                    Title = "Cycling",
                    Description = "Riding a bike or a bike machine",
                    Sets = new List<SetDTO> ()
                    {
                        new SetDTO ()
                        {
                            Duration = 1000,
                            SetDescription = "Sprint"
                        },
                        new SetDTO ()
                        {
                            Duration = 120,
                            SetDescription = "interval"
                        },
                        new SetDTO ()
                        {
                            Duration = 300,
                            SetDescription = "Sprint"
                        }
                    }
                }
            };

            _exercisesInfo = new List<ExerciseInfoDTO>()
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


        public List<ExerciseDTO> GetExerciseList()
        {
            return _exercises;

        }

        public ExerciseDTO GetByIdAsync(int id)
        {
            return _exercises.FirstOrDefault(exercise => exercise.Id == id);
        }
    }
}
