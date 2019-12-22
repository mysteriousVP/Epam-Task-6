using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Helper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductToReturnDTO>();
            CreateMap<ProductToCreateDTO, Product>();

            CreateMap<Order, OrderToReturnDTO>();
            CreateMap<OrderToCreateDTO, Order>();

            CreateMap<Product_Category, ProductToReturnDTO>()
                .ForMember(p => p.ProductName,
                opt => opt.MapFrom(x => x.Product.ProductName))
                .ForMember(p => p.ProductAbout,
                opt => opt.MapFrom(x => x.Product.ProductAbout));
            CreateMap<Product_Category, CategoryToReturnDTO>()
                .ForMember(p => p.CategoryName,
                opt => opt.MapFrom(x => x.Category.CategoryName));

            CreateMap<Provider, ProviderToReturnDTO>();
            CreateMap<ProviderToCreateDTO, Provider>();

            CreateMap<Category, CategoryToReturnDTO>();
            CreateMap<CategoryToCreateDTO, Category>();
        }
    }
}
