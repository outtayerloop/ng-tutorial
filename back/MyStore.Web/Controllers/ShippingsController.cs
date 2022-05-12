using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Domain.Service.Store;

namespace MyStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingsController : Controller
    {
        private readonly IStoreApplication _storeApplication;
        private readonly IMapper _mapper;

        public ShippingsController(IStoreApplication storeApplication)
        {
            _storeApplication = storeApplication;
            _mapper = Mapping.GetMapper();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ShippingDto>> GetAllShippings()
        {
            var shippings = _storeApplication.GetAllShippings();
            return shippings.Select(s => _mapper.Map<ShippingDto>(s)).ToList();
        }
    }
}
