using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.Home;
using OnlineStore.Domain.Contracts.Services;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly IMapper _mapper;

        private List<LaptopItemModel> _laptops = new();

        public HomeController(IHomeService homeService, IMapper mapper)
        {
            _homeService = homeService;
            _mapper = mapper;
        }

        [HttpGet("laptops")]
        public ActionResult<IEnumerable<LaptopItemModel>> GetLaptops()
        {
            var laptops = _homeService.GetLaptops().Select(l => _mapper.Map<LaptopItemModel>(l));

            return Ok(_laptops);
        }
    }
}
