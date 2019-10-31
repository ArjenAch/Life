using Life.Application.Mapping.DTO;
using Life.Application.Services.Exercises.DTO;
using Life.Core.Domain.Exercises;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Interfaces.Exercises
{
    public interface IExerciseInfoService
    {
        Task<IEnumerable<ExerciseInfoDTO>> GetAllAsync();
        Task<ExerciseInfoDTO> GetByIdAsync(int id);
        Task AddAsync(ExerciseInfoDTO exerciseInfo);
        void Update(ExerciseInfoDTO exerciseInfo);
        Task<bool> Exists(int id);
        Task RemoveAsync(int id);
        Task<OperationResponse> SaveAsync();


    }
}
