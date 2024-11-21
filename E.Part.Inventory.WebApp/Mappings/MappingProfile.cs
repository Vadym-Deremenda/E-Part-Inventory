using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.DTOs;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace E.Part.Inventory.WebApp.Mappins;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderHistoryDto>()
            .ForMember(dest => dest.OrederId, opt => opt.MapFrom(src => src.OrederId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));
    }
}