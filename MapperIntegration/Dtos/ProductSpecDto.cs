using AutoMapper;
using MapperIntegration.Data.Models;

namespace MapperIntegration.Dtos
{
    public class ProductSpecDto
    {
        public string Size { get; set; } = string.Empty;
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public decimal DeliveryFee { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsNew { get; set; }
    }

    public class ProductSpecDtoProfile : Profile
    {
        public ProductSpecDtoProfile()
        {
            CreateMap<ProductSpec, ProductSpecDto>();
        }
    }
}
