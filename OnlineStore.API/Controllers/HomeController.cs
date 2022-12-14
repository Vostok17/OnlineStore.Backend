using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.Home;
using OnlineStore.Domain.Contracts.Services;
using OnlineStore.Domain.Entities;

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
            IEnumerable<Laptop> laptops = _homeService.GetLaptops();
            var laptopItemModels = _mapper.Map<IEnumerable<LaptopItemModel>>(laptops);

            return Ok(laptopItemModels);
        }
    }
}
