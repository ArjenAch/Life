using AutoMapper;
using Life.Application.Services.Exercise.DTO;
using Life.Application.Services.Interfaces.Exercise;
using Life.Application.Services.Interfaces.Util;
using Life.Core.Domain.Exercise;
using Life.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Life.Application.Services.Exercise
{
    public class ExerciseInfoService : BaseService, IExerciseInfoService
    {
        private readonly IMapper _mapper;

        public ExerciseInfoService(LifeDbContext context, IMapper mapper, IUserFriendlyExceptionMapper exceptionMapper) : base(context, exceptionMapper)
        {
            this._mapper = mapper;
        }
        public async Task AddAsync(ExerciseInfoDTO exerciseInfo)
        {
            var potentialEntity = _mapper.Map<ExerciseInfo>(exerciseInfo);
            await _context.Set<ExerciseInfo>().AddAsync(potentialEntity);
        }

        public async Task<bool> Exists(int id)
        {
            if (await _context.Set<ExerciseInfo>().FindAsync(id) != null)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ExerciseInfoDTO>> GetAllAsync()
        {
            var entities = await _context.Set<ExerciseInfo>().ToListAsync();
            var infoDTOs = _mapper.Map<IEnumerable<ExerciseInfoDTO>>(entities);

            return infoDTOs;
        }

        public async Task<ExerciseInfoDTO> GetByIdAsync(int id)
        {
            var entity = await _context.Set<ExerciseInfo>().FindAsync(id);
            var infoDTO = _mapper.Map<ExerciseInfoDTO>(entity);

            return infoDTO;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _context.Set<ExerciseInfo>().FindAsync(id);

            if (entity != null)
            {
                _context.Set<ExerciseInfo>().Remove(entity);
            }
        }

        public void Update(ExerciseInfoDTO exerciseInfo)
        {
            var updatedentity = _mapper.Map<ExerciseInfo>(exerciseInfo);
            var entity = _context.Set<ExerciseInfo>().Attach(updatedentity);
            entity.State = EntityState.Modified;
        }
    }
}
