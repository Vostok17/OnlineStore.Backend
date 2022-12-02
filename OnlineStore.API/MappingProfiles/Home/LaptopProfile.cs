using AutoMapper;
using OnlineStore.API.Models.Home;
using OnlineStore.Domain.Entities;

namespace OnlineStore.API.MappingProfiles.Home
{
    public class LaptopProfile : Profile
    {
        public LaptopProfile()
        {
            CreateMap<Laptop, LaptopModel>();
        }
    }
}
