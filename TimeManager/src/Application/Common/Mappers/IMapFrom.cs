﻿using AutoMapper;

namespace TimeManager.Application.Common.Mappers
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
