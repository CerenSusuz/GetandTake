using AutoMapper;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;

namespace GetandTake.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductsDTO>()
                .ForMember(dto => dto.Category,
             entity => entity.MapFrom(entity => entity.Category.CategoryName))
             .ForMember(dto => dto.Supplier,
             entity => entity.MapFrom(entity => entity.Supplier.CompanyName));
        }
    }
}
