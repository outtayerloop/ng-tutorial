using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Store;
using MyStore.Core.Domain.Service.Validation;

namespace MyStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IStoreApplication _storeApplication;
        private readonly IMapper _mapper;
        private readonly IProductValidator _productValidator;

        public ProductsController(
            IStoreApplication storeApplication,
            IProductValidator productValidator)
        {
            _storeApplication = storeApplication;
            _mapper = Mapping.GetMapper();
            _productValidator = productValidator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ProductDto>> GetAllProducts()
        {
            var products = _storeApplication.GetAllProducts();
            return products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<ProductDto>> AddProductRange([FromBody] List<ProductDto> products)
        {
            List<ProductModel> models = products.Select(p => _mapper.Map<ProductModel>(p)).ToList();
            IReadOnlyList<ValidationResult> validationResults = _productValidator.ValidateRange(models);
            if(HasInvalidItems(validationResults))
            {
                var validationData = validationResults.Select(r => _mapper.Map<ValidationResultDto>(r)).ToList();
                return BadRequest(validationData);
            }
            else
            {
                List<Product> newProducts = products.Select(p => _mapper.Map<Product>(p)).ToList();
                List<Product> createdProducts = _storeApplication.AddProductRange(newProducts);
                return createdProducts.Select(p => _mapper.Map<ProductDto>(p)).ToList();
            }
        }

        private bool HasInvalidItems(IReadOnlyList<ValidationResult> validationResults)
            => validationResults.Any(result => !result.IsValid);
    }
}
