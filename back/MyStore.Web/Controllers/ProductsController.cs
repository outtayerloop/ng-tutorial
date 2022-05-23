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
        private readonly IValidator _productValidator;

        public ProductsController(
            IStoreApplication storeApplication, 
            Func<ValidatorType, IValidator> validatorResolver)
        {
            _storeApplication = storeApplication;
            _mapper = Mapping.GetMapper();
            _productValidator = validatorResolver(ValidatorType.Product);
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
            ValidationModel validationResult = _productValidator.ValidateCreationRange(products);
            if (validationResult.Status == ValidationStatus.Valid)
            {
                List<Product> newProducts = products.Select(p => _mapper.Map<Product>(p)).ToList();
                List<Product> createdProducts = _storeApplication.AddProductRange(newProducts);
                return createdProducts.Select(p => _mapper.Map<ProductDto>(p)).ToList();
            }
            ValidationDto validationData = _mapper.Map<ValidationDto>(validationResult);
            return BadRequest(validationData);
        }
    }
}
