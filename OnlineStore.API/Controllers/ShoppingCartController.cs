using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.ShoppingCart;
using OnlineStore.Domain.Entities;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private static readonly List<Laptop> _domainLaptopData = new()
        {
            new Laptop()
            {
                Id = 0,
                Title = "ASUS Vivobook 15 X1502ZA-BQ641",
                ImageLink = "https://content1.rozetka.com.ua/goods/images/big/297014689.jpg",
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
                ImageLink = "https://content1.rozetka.com.ua/goods/images/big/248481392.jpg",
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
            new Laptop()
            {
                Id = 2,
                Title = "Apple MacBook Air 13\" M1 256GB 2020",
                ImageLink = "https://content.rozetka.com.ua/goods/images/big/30872664.jpg",
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

        private List<LaptopModel> _laptops = new();

        public ShoppingCartController(IMapper mapper)
        {
            _mapper = mapper;

            foreach (var laptop in _domainLaptopData)
            {
                _laptops.Add(_mapper.Map<LaptopModel>(laptop));
            }
        }

        [HttpPost]
        public ActionResult<IEnumerable<LaptopModel>> PostShoppingCart(List<LaptopModel> laptops)
        {
            return Ok(laptops);
        }

        [HttpGet]
        public ActionResult<IEnumerable<LaptopModel>> GetShoppingCart()
        {
            return Ok(_laptops);
        }
    }
}
