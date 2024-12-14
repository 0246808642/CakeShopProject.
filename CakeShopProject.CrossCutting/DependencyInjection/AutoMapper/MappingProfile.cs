using AutoMapper;
using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Entities.Dtos.City;

namespace CakeShopProject.CrossCutting.DependencyInjection.AutoMapper.Config;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<City, CityInsertRequestDto>().ReverseMap();
        CreateMap<City, CityUpdateRequestDto>().ReverseMap();
    }
}
