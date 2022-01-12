using MapperIntegration.Data.Models;
using Mapster;

namespace MapperIntegration.Dtos
{
    public class ShoppingCartDto
    {
        public string ProductNo { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? ProductName { get; set; }
        public IEnumerable<string> Images { get; set; } = new HashSet<string>();
    }

    public class ShoppingCartDtoRegistration : IRegister
    {
        void IRegister.Register(TypeAdapterConfig config)
        {
            config.NewConfig<ShoppingCart, ShoppingCartDto>()
                //.Map(p=> p.ProductNo, p=> p.ProductNo)
                //.Map(p => p.Size, p => p.Size)
                //.Map(p => p.Qty, p => p.Qty)
                .Map(p => p.UnitPrice, p => p.ProductSpec.Price)
                .Map(p => p.ProductName, p => p.ProductSpec.ProductNoNavigation.ProductName)
                .Map(p => p.Images, p => p.ProductSpec.ProductNoNavigation.ProductImages.Select(i => i.Url));
        }
    }
}
