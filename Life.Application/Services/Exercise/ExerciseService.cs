using AutoMapper;
using Life.Application.Services.Exercise.DTO;
using Life.Application.Services.Interfaces.Exercise;
using Life.Core.Domain.Exercise;
using Life.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Exercise
{
    public class ExerciseService : BaseService, IExerciseService
    {
        private readonly IMapper _mapper;

        public ExerciseService(LifeDbContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public Task AddAsync(ExerciseInfoDTO exerciseInfo, List<SetDTO> sets)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllAsync()
        {
            var entities = await _context.Exercises.ToListAsync(); //.Include<ExerciseInfo>().
            var infoDTOs = _mapper.Map<IEnumerable<ExerciseDTO>>(entities);

            return infoDTOs;
        }

        public Task<ExerciseDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(ExerciseDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
