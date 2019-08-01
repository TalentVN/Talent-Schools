using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Entities;
using TSM.Models;
using TSM.Models.ResponseModels;

namespace TSM.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IdentityResult, CreateUserResponseModel>();
            CreateMap<SignInResult, LoginResponseModel>();
            CreateMap<School, SchoolResponseModel>();
            CreateMap<Location, LocationResponseModel>();
            CreateMap<EducationProgram, EducationProgramModel>();
            CreateMap<Major, MajorModel>();
            CreateMap<Rating, RatingModel>();
        }
    }
}
