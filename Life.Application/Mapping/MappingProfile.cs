using AutoMapper;
using Life.Application.Services.Exercises.DTO;
using Life.Core.Domain.Exercises;
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
            CreateMap<Exercise, ExerciseDTO>()
                .ForMember(destination => destination.InfoId, opt => opt.MapFrom(src => src.ExerciseInfo.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.ExerciseInfo.Title))
                .ForMember(destination => destination.Description, opt => opt.MapFrom(src => src.ExerciseInfo.Description))
                .ForMember(destination => destination.ExerciseType, opt => opt.MapFrom(src => src.ExerciseInfo.ExerciseType))
                .ReverseMap();

            CreateMap<Exercise, ExerciseInfo>().ReverseMap();
            CreateMap<ExerciseDTO, ExerciseInfoDTO>().ReverseMap();
            CreateMap<SetDTO, WeightSet>().ReverseMap();
            CreateMap<SetDTO, DurationSet>()
                .ForMember(destination => destination.Description, opt => opt.MapFrom(src => src.SetDescription))
                .ReverseMap();
        }
    }
}
