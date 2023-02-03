using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.WebAPI.Model.OrderProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OnProgressProductController
    {

        private IDomain _domain;
        private readonly IMapper _mapper;

        public OnProgressProductController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderProductShowDTO?>> Get(long restaurantId)
        {
            return _mapper.Map<IEnumerable<OrderProductShowDTO>>(await _domain.getOnProgressProductsFromRestaurant(restaurantId));
        }
    }
}
