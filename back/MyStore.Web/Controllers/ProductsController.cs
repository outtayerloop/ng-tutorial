using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Application;
using MyStore.Core.Domain;

namespace MyStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IStoreApplication _storeApplication;

        public ProductsController(IStoreApplication storeApplication)
            => _storeApplication = storeApplication;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ProductDto>> GetAllProducts()
            => _storeApplication.GetAllProducts();
    }
}
