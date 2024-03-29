﻿using Life.Application.Services.Exercise.DTO;
using Life.Core.Domain.Exercise;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Interfaces.Exercise
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseInfoDTO>> GetAllAsync();
        Task<ExerciseInfoDTO> GetByIdAsync(int id);
        Task AddAsync(ExerciseInfoDTO entity);
        void Update(ExerciseInfoDTO entity);
        Task<bool> Exists(int id);
        Task RemoveAsync(int id);
        Task SaveAsync();


    }
}
