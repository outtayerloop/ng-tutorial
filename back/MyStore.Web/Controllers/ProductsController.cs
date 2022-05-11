using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Domain.Service;

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
            var products = _storeApplication.GetAllProducts();
            return products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
        }
    }
}
