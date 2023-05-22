using AutoMapper;
using LightweightGymAPI.Dto;
using LightweightGymAPI.Entities;

namespace LightweightGymAPI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Activity, ActivityDto>();
        }

    }
}
