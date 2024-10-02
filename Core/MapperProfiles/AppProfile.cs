using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<EditDoctorDto, Doctor>();
            CreateMap<DoctorDto, Doctor>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<EditCategoryDto, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<RegisterDto, User>()
               .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Email));


        }
    }
}
