using AutoMapper.Configuration;
using Try1975.Nevlabs.Dto;
using Try1975.Nevlabs.Entities;

namespace Try1975.Nevlabs.AutoMapper
{
    public static class PersonAutoMapper
    {
        public static void Configure(MapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PersonEntity, PersonDto>()
                ;
            cfg.CreateMap<PersonDto, PersonEntity>()
                ;
        }
    }
}