using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.ShoppingCart;
using OnlineStore.Domain.Contracts.Services;
using OnlineStore.Domain.Entities;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<IEnumerable<LaptopCartModel>> PostShoppingCart(List<LaptopCartModel> laptops)
        {
            return CreatedAtRoute("GetShoppingCart", laptops);
        }

        [HttpGet(Name = "GetShoppingCart")]
        public ActionResult<IEnumerable<LaptopCartModel>> GetShoppingCart()
        {
            IEnumerable<Laptop> laptops = _shoppingCartService.GetLaptops();
            var laptopCartModels = _mapper.Map<IEnumerable<LaptopCartModel>>(laptops);

            return Ok(laptopCartModels);
        }
    }
}
