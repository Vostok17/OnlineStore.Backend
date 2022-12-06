using AutoMapper;
using OnlineStore.Domain.Entities;

namespace OnlineStore.API.Models.Home
{
    public class LaptopModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageLink { get; set; }

        public decimal Price { get; set; }

        private class LaptopProfile : Profile
        {
            public LaptopProfile()
            {
                CreateMap<Laptop, LaptopModel>();
            }
        }
    }
}
