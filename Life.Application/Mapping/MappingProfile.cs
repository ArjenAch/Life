using AutoMapper;
using Life.Application.Services.Exercise.DTO;
using Life.Core.Domain.Exercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExerciseInfo, ExerciseInfoDTO>().ReverseMap();
        }
    }
}
