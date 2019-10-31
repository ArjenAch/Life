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
    public class ExerciseService : BaseService, IExerciseService
    {
        private readonly IMapper _mapper;
        private readonly IExerciseInfoService _exerciseInfoService;

        public ExerciseService(LifeDbContext context, IMapper mapper, 
            IExerciseInfoService exerciseInfoService, IUserFriendlyExceptionMapper exceptionMapper)
            : base(context, exceptionMapper)
        {
            this._mapper = mapper;
            this._exerciseInfoService = exerciseInfoService;
        }
        
        //TODO : somewhere add a check if at least one set is added & sets within a exercise are of the same type implementation
        public async Task AddAsync(ExerciseDTO exerciseDTO)
        {
            ExerciseInfoDTO exerciseInfo;
            var exercise = new Core.Domain.Exercise.Exercise() { Sets = new List<Set>()};

            exerciseInfo = _mapper.Map<ExerciseDTO, ExerciseInfoDTO>(exerciseDTO);
            exerciseInfo.Id = exerciseDTO.InfoId;
            exercise.ExerciseInfo = _mapper.Map<ExerciseInfoDTO, ExerciseInfo>(exerciseInfo);

            if (!await _exerciseInfoService.Exists(exerciseDTO.InfoId))
            {
                await _exerciseInfoService.AddAsync(exerciseInfo);
            }           

            if( exerciseDTO.ExerciseType == ExerciseType.Strength)
            {
                var list = _mapper.Map<List<SetDTO>, List<WeightSet>>(exerciseDTO.Sets);
                foreach (var item in list) //check
                {
                    exercise.Sets.Add(item);
                }
            }
            else
            {
                var list = _mapper.Map<List<SetDTO>, List<DurationSet>>(exerciseDTO.Sets);
                foreach (var item in list)
                {
                    exercise.Sets.Add(item);
                }
            }

            await _context.AddAsync(exercise);
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllAsync()
        {
            var entities = await _context.Exercises.ToListAsync(); //.Include<ExerciseInfo>().
            var exercises = _mapper.Map<IEnumerable<ExerciseDTO>>(entities);

            return exercises;
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
