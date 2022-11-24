using AutoMapper;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Business.Services.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDetail>().ReverseMap();
        CreateMap<Product, ProductResponse>()
            .ForMember(dto => dto.Category,
                                  entity => entity.MapFrom(entity =>
     entity.Category.CategoryName))
            .ForMember(dto => dto.Supplier,
                               entity => entity.MapFrom(entity =>
     entity.Supplier.CompanyName));
    }
}
