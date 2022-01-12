using AutoMapper;
using MapperIntegration.Data.Models;
using Mapster;

namespace MapperIntegration.Dtos
{
    public class ProductDto
    {
        public string ProductNo { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public IEnumerable<string> Images { get; set; } = new HashSet<string>();
        public IEnumerable<ProductSpecDto> Specs { get; set; } = new HashSet<ProductSpecDto>();
    }

    public class ProductDtoProfile : Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<Product, ProductDto>()
                //.ForMember(p => p.ProductNo, m => m.MapFrom(p => p.ProductNo))
                //.ForMember(p => p.ProductName, m => m.MapFrom(p => p.ProductName))
                //.ForMember(p => p.Brand, m => m.MapFrom(p => p.Brand))
                //.ForMember(p => p.Category, m => m.MapFrom(p => p.Category))
                //.ForMember(p => p.Description, m => m.MapFrom(p => p.Description))
                .ForMember(p => p.MinPrice, m => m.MapFrom(p => p.ProductSpecs.Min(s => s.Price)))
                .ForMember(p => p.MaxPrice, m => m.MapFrom(p => p.ProductSpecs.Max(s => s.Price)))
                .ForMember(p => p.Images, m => m.MapFrom(p => p.ProductImages.Select(i => i.Url)))
                .ForMember(p => p.Specs, m => m.MapFrom(p => p.ProductSpecs));
        }
    }

    public class ProductDtoRegistration : IRegister
    {
        void IRegister.Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDto>()
                .Map(p => p.MinPrice, p => p.ProductSpecs.Min(s => s.Price))
                .Map(p => p.MaxPrice, p => p.ProductSpecs.Max(s => s.Price))
                .Map(p => p.Images, p => p.ProductImages.Select(i => i.Url))
                .Map(p => p.Specs, p => p.ProductSpecs);
        }
    }
}
