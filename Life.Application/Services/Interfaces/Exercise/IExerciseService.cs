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
        Task<IEnumerable<ExerciseDTO>> GetAllAsync();
        Task<ExerciseDTO> GetByIdAsync(int id);
        Task AddAsync(ExerciseInfoDTO exerciseInfo, List<SetDTO> sets);
        void Update(ExerciseDTO entity);
        Task<bool> Exists(int id);
        Task RemoveAsync(int id);
        Task SaveAsync();


    }
}
