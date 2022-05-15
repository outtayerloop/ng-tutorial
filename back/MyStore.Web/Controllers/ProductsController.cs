using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Service.Store;

namespace MyStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IStoreApplication _storeApplication;
        private readonly IMapper _mapper;

        public ProductsController(IStoreApplication storeApplication)
        {
            _storeApplication = storeApplication;
            _mapper = Mapping.GetMapper();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ProductDto>> GetAllProducts()
        {
            List<Product> products = _storeApplication.GetAllProducts();
            return products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<ProductDto>> AddProductRange([FromBody] List<ProductDto> products)
        {
            List<Product> newProducts = products.Select(p => _mapper.Map<Product>(p)).ToList();
            List<Product> createdProducts = _storeApplication.AddProductRange(newProducts);
            return createdProducts.Select(p => _mapper.Map<ProductDto>(p)).ToList();
        }
    }
}
