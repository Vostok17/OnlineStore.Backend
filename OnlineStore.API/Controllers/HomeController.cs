using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.Home;
using OnlineStore.Domain.Entities;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private static readonly Laptop[] _laptops = new[]
        {
            new Laptop()
            {
                Id = 0,
                Title = "ASUS Vivobook 15 X1502ZA-BQ641",
                ImageLink = "laptopImg",
                Price = 31999m,
                Diagonal = "13.3\" (2560x1600) WQXGA",
                RefreshRate = "60 Hz",
                Cpu = "Octa-core Apple M1",
                OperatingSystem = "macOS Big Sur",
                AmountOfRam = "4 Gb",
                Ssd = "256 Gb",
                Gpu = "Integrated",
                WiFi = string.Empty,
                Bluetooth = "5.0",
            },
            new Laptop()
            {
                Id = 1,
                Title = "Acer Aspire 5 A515-45G-R9ML",
                ImageLink = "acerImg",
                Price = 26999m,
                Diagonal = "13.3\" (2560x1600) WQXGA",
                RefreshRate = "60 Hz",
                Cpu = "Octa-core Apple M1",
                OperatingSystem = "macOS Big Sur",
                AmountOfRam = "4 Gb",
                Ssd = "256 Gb",
                Gpu = "Integrated",
                WiFi = string.Empty,
                Bluetooth = "5.0",
            },
        };

        private readonly IMapper _mapper;

        public HomeController(IMapper mapper) => _mapper = mapper;

        [HttpGet("laptops")]
        public ActionResult<IEnumerable<Laptop>> GetLaptops()
        {
            var homeLaptops = new List<LaptopModel>();
            foreach (var laptop in _laptops)
            {
                homeLaptops.Add(_mapper.Map<LaptopModel>(laptop));
            }

            return Ok(homeLaptops);
        }
    }
}
