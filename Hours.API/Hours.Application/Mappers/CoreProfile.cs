using AutoMapper;
using Hours.Application.DataContract.Request.Hours;
using Hours.Application.DataContract.Request.User;
using Hours.Application.DataContract.Response.Hours;
using Hours.Application.DataContract.Response.User;
using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Models;

namespace Hours.Application.Mappers
{
    public sealed class CoreProfile : Profile
    {
        public CoreProfile()
        {
            HoursMap();
        }

        private void HoursMap()
        {
            CreateMap<HoursRequest, HoursEntity>();
            CreateMap<HoursEntity, HoursGeneralResponse>();
            CreateMap<HoursGeneralResponse, HoursEntity>();
            CreateMap<HoursModelsResponse, HoursRankingResponse>();
            CreateMap<HoursFilterRequest , HoursFilters>();


            CreateMap<UserFilterRequest, UserFilters>();
            CreateMap<UserRequest, UsersEntity>();
            CreateMap<UsersEntity, UserResponse>();
        }
    }
}
