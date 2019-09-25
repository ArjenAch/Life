using Life.Core.Domain.Exercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Data.Repositories.Interfaces
{
    public interface IExerciseInfoRepository
    {
        ExerciseInfo Add(ExerciseInfo exerciseInfo);
        IEnumerable<ExerciseInfo> GetExercisesInfo();
        ExerciseInfo Get(int id);
        ExerciseInfo Delete(int id);
        ExerciseInfo Update(ExerciseInfo exerciseInfo);
    }
}
