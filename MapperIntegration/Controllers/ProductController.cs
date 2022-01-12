using AutoMapper;
using AutoMapper.QueryableExtensions;
using MapperIntegration.Data;
using MapperIntegration.Dtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapperIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DemoDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductController(DemoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("Query1")]
        public IEnumerable<ProductDto> Query1()
        {
            return _dbContext.Products
                .Select(p => new ProductDto
                {
                    ProductNo = p.ProductNo,
                    ProductName =p.ProductName,
                    Brand =p.Brand,
                    Category =p.Category,
                    Description =p.Description,
                    MinPrice =p.ProductSpecs.Min(spec => spec.Price),
                    MaxPrice =p.ProductSpecs.Max(spec => spec.Price),
                    Images = p.ProductImages.Select(img => img.Url),
                    Specs = p.ProductSpecs.Select(spec => new ProductSpecDto
                    {
                        Size = spec.Size,
                        Qty = spec.Qty,
                        Price = spec.Price,
                        Description = spec.Description,
                        DeliveryFee = spec.DeliveryFee,
                        IsDiscounted =  spec.IsDiscounted,
                        IsNew = spec.IsNew,
                    }),
                });
        }

        [HttpGet("Query2")]
        public IEnumerable<ProductDto> Query2()
        {
            return _dbContext.Products
                .Include(p => p.ProductSpecs)
                .Include(p => p.ProductImages)
                .Select(p => _mapper.Map<ProductDto>(p));
        }

        [HttpGet("Query3")]
        public IEnumerable<ProductDto> Query3()
        {
            // 使用 AutoMapper 的 ProjectTo
            //return _dbContext.Products
            //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider);

            // AutoMapper 的另一種寫法
            //return _mapper.ProjectTo<ProductDto>(_dbContext.Products);

            // 使用 AutoMapper 的 ProjectToType
            return _dbContext.Products.ProjectToType<ProductDto>();
        }
    }
}
