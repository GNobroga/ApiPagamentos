using ApiPagamentos.Entities;
using AutoMapper;

namespace ApiPagamentos.ValueObjects.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Venda, VendaVO>().ReverseMap();
    }
}