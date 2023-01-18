using OnlineStore.Domain.Contracts.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Tests.TestRepositories
{
    public class TestsPurchaseRepository : IPurchaseRepository
    {
        private static readonly Guid _token = Guid.NewGuid();

        private readonly List<PurchasedItem> _purchasedItems = new List<PurchasedItem>
        {
            new PurchasedItem
            {
                Id = 0,
                LaptopId = 0,
                Date = DateTime.Now,
                PurchaseToken = _token,
            },
            new PurchasedItem
            {
                Id = 1,
                LaptopId = 1,
                Date = DateTime.Now,
                PurchaseToken = _token,
            },
            new PurchasedItem
            {
                Id = 2,
                LaptopId = 2,
                Date = DateTime.Now,
                PurchaseToken = _token,
            },
        };

        public Task<int> CreateAsync(PurchasedItem entity)
        {
            return Task.Run(() =>
            {
                Parallel.For(0, entity.Count, _ => _purchasedItems.Add(entity));

                const int affectedRows = 1;
                return affectedRows;
            });
        }

        public async Task<int> CreateRangeAsync(IEnumerable<PurchasedItem> entities)
        {
            var tasks = entities.Select(async e => await CreateAsync(e));
            await Task.WhenAll(tasks);

            int affectedRows = entities.Count();
            return affectedRows;
        }

        public Task<int> DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                PurchasedItem item = _purchasedItems.Where(i => i.Id == id).First();
                int index = _purchasedItems.IndexOf(item);

                int affectedRows = 0;
                if (index != -1)
                {
                    _purchasedItems.RemoveAt(index);
                    affectedRows++;
                }

                return affectedRows;
            });
        }

        public Task<IEnumerable<PurchasedItem>> GetAllAsync()
        {
            return Task.Run<IEnumerable<PurchasedItem>>(() => _purchasedItems);
        }

        public Task<PurchasedItem> GetByIdAsync(int id)
        {
            return Task.Run(() => _purchasedItems.Where(i => i.Id == id).SingleOrDefault());
        }

        public Task<IEnumerable<PurchasedItem>> GetByToken(Guid token)
        {
            return Task.Run(() => _purchasedItems.Where(i => i.PurchaseToken == token));
        }

        public Task<int> UpdateAsync(PurchasedItem entity)
        {
            return Task.Run(() =>
            {
                PurchasedItem previousItem = _purchasedItems.Where(i => i.Id == entity.Id).First();
                int index = _purchasedItems.IndexOf(previousItem);

                int affectedRows = 0;
                if (index != -1)
                {
                    _purchasedItems[index] = entity;
                    affectedRows++;
                }

                return affectedRows;
            });
        }
    }
}
