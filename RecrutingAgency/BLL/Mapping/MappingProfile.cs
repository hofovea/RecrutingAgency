using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using BLL.DTO.Identity;
using BLL.DTO.JobPosting;
using DAL.Entities;
using DAL.Identity;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Role, RoleDto>();
            CreateMap<UserToRole, RoleDto>();

            CreateMap<JobPosting, JobPostingDto>()
                .ReverseMap();
            CreateMap<CreateJobPostingDto, JobPosting>();
            CreateMap<UpdateJobPostingDto, JobPosting>();
        }
    }
}
