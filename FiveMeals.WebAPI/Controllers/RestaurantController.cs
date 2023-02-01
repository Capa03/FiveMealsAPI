using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Restaurant;
using FiveMeals.WebAPI.Model.Table;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private IDomain _domain;
        private readonly IMapper _mapper;

        public RestaurantController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        public IEnumerable<ShowRestaurantDTO>? Get()
        {
            return _mapper.Map<IEnumerable<ShowRestaurantDTO>>(_domain.GetAllRestaurants());

        }
        [HttpGet("{restaurantId}")]
        public ShowRestaurantDTO? Get(int restaurantId)
        {
            return _mapper.Map<ShowRestaurantDTO>(_domain.GetRestaurant(restaurantId));
        }

        [HttpPost]
        public void Create(CreateRestaurantDTO RestaurantIn)
        {
             _domain.CreateRestaurant(_mapper.Map<Restaurant>(RestaurantIn));

        }

       
    }
}
