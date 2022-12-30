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
        private readonly IShoppingCartService _purchaseService;

        public ShoppingCartController(IShoppingCartService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<IEnumerable<LaptopCartModel>>> Post(List<(int Id, int Count)> items, int userId)
        {
            Guid token = await _purchaseService.ProcessPurchaseAsync(items, userId);

            return CreatedAtRoute("GetShoppingCart", token, await GetShoppingCart(token));
        }

        [HttpGet("{token}", Name = "GetShoppingCart")]
        public async Task<ActionResult<IEnumerable<LaptopCartModel>>> GetShoppingCart(Guid token)
        {
            IEnumerable<PurchasedItem> items = await _purchaseService.GetItemsByPurchaseToken(token);

            if (items is null)
            {
                return NotFound();
            }

            return Ok(items);
        }
    }
}
