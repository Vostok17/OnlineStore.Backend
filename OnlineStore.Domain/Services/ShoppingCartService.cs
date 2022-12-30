using OnlineStore.Domain.Contracts.Repositories;
using OnlineStore.Domain.Contracts.Services;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Services
{
    public class ShoppingCartSevice : IShoppingCartService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public ShoppingCartSevice(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Guid> ProcessPurchaseAsync(List<(int Id, int Count)> data, int userId)
        {
            // Validation here.
            Guid token = Guid.NewGuid();

            foreach (var item in data)
            {
                var (id, count) = item;
                var purchasedItem = new PurchasedItem
                {
                    LaptopId = id,
                    UserId = userId,
                    Date = DateTime.Now,
                    PurchaseToken = token,
                };

                for (int i = 0; i < count; i++)
                {
                    await _purchaseRepository.CreateAsync(purchasedItem);
                }
            }

            return token;
        }

        public async Task<IEnumerable<PurchasedItem>> GetItemsByPurchaseToken(Guid token)
        {
            return await _purchaseRepository.GetByToken(token);
        }
    }
}
