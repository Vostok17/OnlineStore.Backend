using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.ProductDetails;
using OnlineStore.Domain.Contracts.Services;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _productDetailsService;
        private readonly IMapper _mapper;

        public ProductDetailsController(IProductDetailsService productDetailsService, IMapper mapper)
        {
            _productDetailsService = productDetailsService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<LaptopDetailsModel> GetLaptopDetails(int id)
        {
            var laptopDetails = _productDetailsService.GetLaptopDetailsById(id);

            if (laptopDetails is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LaptopDetailsModel>(laptopDetails));
        }
    }
}
