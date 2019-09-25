using System;
using System.Collections.Generic;
using System.Text;
using Life.Core.Domain;
using Life.Core.Domain.Exercise;

namespace Life.Data.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        Exercise Add(Exercise exercise);
        IEnumerable<Exercise> GetExercises();
        Exercise Get(int id);
        Exercise Delete(int id);
        Exercise Update(Exercise exercise);
    }
}
