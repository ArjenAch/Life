using Life.Core.Domain.Exercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Data.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        Workout Add(Workout workout);
        IEnumerable<Workout> GetWorkoutss();
        Workout Get(int id);
        Workout Delete(int id);
        Workout Update(Workout workout);
    }
}
