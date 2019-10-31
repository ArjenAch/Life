using Life.Application.Mapping.DTO;
using Life.Application.Services.Exercises.DTO;
using Life.Core.Domain.Exercises;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Interfaces.Exercises
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDTO>> GetAllAsync();
        Task<ExerciseDTO> GetByIdAsync(int id);
        Task AddAsync(ExerciseDTO exerciseDTO);
        void Update(ExerciseDTO entity);
        Task<bool> Exists(int id);
        Task RemoveAsync(int id);
        Task<OperationResponse> SaveAsync();
    }
}
