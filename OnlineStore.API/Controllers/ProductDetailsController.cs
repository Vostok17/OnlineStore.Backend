using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models.ProductDetails;
using OnlineStore.Domain.Contracts.Services;
using OnlineStore.Domain.Entities;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _productDetailsService;
        private readonly IMapper _mapper;

        public ProductDetailsController(IProductDetailsService productDetailsService, IMapper mapper)
        {
            _productDetailsService = productDetailsService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetLaptopDetails")]
        public async Task<ActionResult<LaptopDetailsModel>> Get(int id)
        {
            Laptop laptop = await _productDetailsService.GetLaptopDetailsAsync(id);

            if (laptop is null)
            {
                return NotFound();
            }

            var laptopDetails = _mapper.Map<LaptopDetailsModel>(laptop);

            return Ok(laptopDetails);
        }

        [HttpPost]
        public async Task<ActionResult<LaptopDetailsModel>> Post(LaptopDetailsModel laptopDetails)
        {
            Laptop laptop = _mapper.Map<Laptop>(laptopDetails);

            laptop.Id = await _productDetailsService.AddLaptopDetailsAsync(laptop);

            return CreatedAtRoute("GetLaptopDetails", new { id = laptop.Id }, laptop);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            bool isDeleted = await _productDetailsService.DeleteLaptopDetailsAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(new { message = $"Laptop with Id = {id} was deleted" });
        }

        [HttpPut]
        public async Task<ActionResult<LaptopDetailsModel>> Update(LaptopDetailsModel laptopDetails)
        {
            Laptop laptop = _mapper.Map<Laptop>(laptopDetails);

            await _productDetailsService.UpdateLaptopDetailsAsync(laptop);

            return Ok(laptopDetails);
        }
    }
}
