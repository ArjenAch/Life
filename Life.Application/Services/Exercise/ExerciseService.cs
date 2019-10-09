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
    public class ExerciseService : IExerciseService
    {
        private readonly LifeDbContext _context;
        private readonly IMapper _mapper;

        public ExerciseService(LifeDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task AddAsync(ExerciseInfoDTO exerciseInfo)
        {
            var potentialEntity = _mapper.Map<ExerciseInfo>(exerciseInfo);
            await _context.Set<ExerciseInfo>().AddAsync(potentialEntity);
        }

        public async Task<bool> Exists(int id)
        {
            if(await _context.Set<ExerciseInfo>().FindAsync(id) != null)
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
        
        //Filter for valid id?
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ExerciseInfoDTO exerciseInfoDTO)
        {
            var updatedentity = _mapper.Map<ExerciseInfo>(exerciseInfoDTO);
            var entity = _context.Set<ExerciseInfo>().Attach(updatedentity);
            entity.State = EntityState.Modified;
        }
    }
}
