using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using RecruitingAgency.Models.JobPosting;
using BLL.DTO.JobPosting;
using RecruitingAgency.Models.User;

namespace RecruitingAgency.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateJobPostingDto, CreateJobPostingModel>().ReverseMap();
            //if not working uncomment following 
            //.ForMember(model => model.EmployerId, m => m.MapFrom(dto => dto.EmployerId));
            CreateMap<UpdateJobPostingDto, UpdateJobPostingModel>().ReverseMap();
            CreateMap<JobPostingDto, JobPostingModel>();
            CreateMap<UserDto, UserModel>()
                .ForMember(r => r.Roles,
                    m => m.MapFrom(
                        roleDto => roleDto.Roles.Select(r => r.Name)));
        }
    }
}
