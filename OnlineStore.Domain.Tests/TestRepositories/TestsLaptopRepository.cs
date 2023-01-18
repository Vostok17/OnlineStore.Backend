using OnlineStore.Domain.Contracts.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Tests.TestRepositories
{
    public class TestsLaptopRepository : ILaptopRepository
    {
        private static readonly List<Laptop> _laptops = new List<Laptop>
            {
                new Laptop
                {
                    Id = 0,
                    Model = "ModelNo1",
                    Price = 1000,
                    AmountOfRam = "...",
                    Bluetooth = "...",
                    Diagonal = "...",
                    ImageLink = "...",
                    OperatingSystem = "...",
                    Processor = "...",
                    RefreshRate = "...",
                    Ssd = "...",
                    VideoCard = "...",
                    WiFi = "...",
                },
                new Laptop
                {
                    Id = 1,
                    Model = "ModelNo2",
                    Price = 2000,
                    AmountOfRam = "...",
                    Bluetooth = "...",
                    Diagonal = "...",
                    ImageLink = "...",
                    OperatingSystem = "...",
                    Processor = "...",
                    RefreshRate = "...",
                    Ssd = "...",
                    VideoCard = "...",
                    WiFi = "...",
                },
                new Laptop
                {
                    Id = 2,
                    Model = "ModelNo3",
                    Price = 3000,
                    AmountOfRam = "...",
                    Bluetooth = "...",
                    Diagonal = "...",
                    ImageLink = "...",
                    OperatingSystem = "...",
                    Processor = "...",
                    RefreshRate = "...",
                    Ssd = "...",
                    VideoCard = "...",
                    WiFi = "...",
                },
                new Laptop
                {
                    Id = 3,
                    Model = "ModelNo4",
                    Price = 4000,
                    AmountOfRam = "...",
                    Bluetooth = "...",
                    Diagonal = "...",
                    ImageLink = "...",
                    OperatingSystem = "...",
                    Processor = "...",
                    RefreshRate = "...",
                    Ssd = "...",
                    VideoCard = "...",
                    WiFi = "...",
                },
                new Laptop
                {
                    Id = 4,
                    Model = "ModelNo5",
                    Price = 1000,
                    AmountOfRam = "...",
                    Bluetooth = "...",
                    Diagonal = "...",
                    ImageLink = "...",
                    OperatingSystem = "...",
                    Processor = "...",
                    RefreshRate = "...",
                    Ssd = "...",
                    VideoCard = "...",
                    WiFi = "...",
                },
                new Laptop
                {
                    Id = 5,
                    Model = "ModelNo6",
                    Price = 1000,
                    AmountOfRam = "...",
                    Bluetooth = "...",
                    Diagonal = "...",
                    ImageLink = "...",
                    OperatingSystem = "...",
                    Processor = "...",
                    RefreshRate = "...",
                    Ssd = "...",
                    VideoCard = "...",
                    WiFi = "...",
                },
            };

        public Task<int> CreateAsync(Laptop entity)
        {
            return Task.Run(() =>
            {
                int nextId = _laptops.Max(l => l.Id) + 1;
                entity.Id = nextId;

                _laptops.Add(entity);
                return nextId;
            });
        }

        public async Task<int> CreateRangeAsync(IEnumerable<Laptop> entities)
        {
            IEnumerable<Task<int>> tasks = entities.Select(async e => await CreateAsync(e));
            await Task.WhenAll(tasks);

            int affectedRows = entities.Count();
            return affectedRows;
        }

        public Task<int> DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                Laptop laptop = _laptops.Where(l => l.Id == id).First();
                int index = _laptops.IndexOf(laptop);

                int affectedRows = 0;

                if (index != -1)
                {
                    _laptops.RemoveAt(index);
                    affectedRows++;
                }

                return affectedRows;
            });
        }

        public Task<IEnumerable<Laptop>> GetAllAsync()
        {
            return Task.Run<IEnumerable<Laptop>>(() => _laptops);
        }

        public Task<Laptop> GetByIdAsync(int id)
        {
            return Task.Run(() => _laptops.Where(laptop => laptop.Id == id).SingleOrDefault());
        }

        public Task<Laptop> GetByModelAsync(string model)
        {
            return Task.Run(() => _laptops.Where(laptop => laptop.Model == model).SingleOrDefault());
        }

        public Task<int> UpdateAsync(Laptop entity)
        {
            return Task.Run(() =>
            {
                Laptop previousLaptop = _laptops.Where(l => l.Id == entity.Id).First();
                int index = _laptops.IndexOf(entity);

                int rowsAffected = 0;
                if (index != -1)
                {
                    _laptops[index] = entity;
                    rowsAffected = 1;
                }

                return rowsAffected;
            });
        }
    }
}
