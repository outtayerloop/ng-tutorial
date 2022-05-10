using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Application;
using MyStore.Core.Data.Dto;

namespace MyStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingsController : Controller
    {
        private readonly IStoreApplication _storeApplication;

        public ShippingsController(IStoreApplication storeApplication)
            => _storeApplication = storeApplication;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ShippingDto>> GetAllShippings()
            => _storeApplication.GetAllShippings();
    }
}
