using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.DTO;
using AutoMapper;

namespace API.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExercisePostDTO, Exercise>();
            CreateMap<ExerciseUpdateDTO, Exercise>();

            CreateMap<Training, TrainingDTO>();
            CreateMap<TrainingPostDTO, Training>();
            CreateMap<TrainingUpdateDTO, Training>();
        }
    }
}