using MapperIntegration.Data;
using MapperIntegration.Dtos;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly DemoDbContext _dbContext;
        private readonly IMapper _mapper;

        public ShoppingCartController(DemoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

            //TypeAdapterConfig<ShoppingCart, ShoppingCartDto>.NewConfig()
            //    .Map(p => p.ProductName, p => p.ProductSpec.ProductNoNavigation.ProductName)
            //    .Map(p => p.Images, p => p.ProductSpec.ProductNoNavigation.ProductImages.Select(i => i.Url));
        }

        [HttpGet("Query1")]
        public IEnumerable<ShoppingCartDto> Query1()
        {
            return _dbContext.ShoppingCarts
                .Select(p => new ShoppingCartDto
                {
                    Qty = p.Qty,
                    ProductNo = p.ProductSpec.ProductNo,
                    Size =p.ProductSpec.Size,
                    UnitPrice = p.ProductSpec.Price,
                    ProductName = p.ProductSpec.ProductNoNavigation.ProductName,
                    Images = p.ProductSpec.ProductNoNavigation.ProductImages.Select(img => img.Url),
                });
        }

        [HttpGet("Query2")]
        public IEnumerable<ShoppingCartDto> Query2()
        {
            return _dbContext.ShoppingCarts
                .Include(p => p.ProductSpec)
                .ThenInclude(p => p.ProductNoNavigation)
                .ThenInclude(p=> p.ProductImages)
                .Select(p => _mapper.Map<ShoppingCartDto>(p));
        }

        [HttpGet("Query3")]
        public IEnumerable<ShoppingCartDto> Query3()
        {
            return _dbContext.ShoppingCarts.ProjectToType<ShoppingCartDto>();
        }
    }
}
