using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using FiveMeals.WebAPI.Model.RestaurantTerminal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RestaurantTerminalController : ControllerBase
    {

        private IDomain _domain;
        private readonly IMapper _mapper;

        public RestaurantTerminalController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpPost]
        public void Create(CreateRestaurantTerminalDTO restaurantTerminalIn)
        {
            _domain.registerRestaurantTerminal(_mapper.Map<RestaurantTerminal>(restaurantTerminalIn));
        }
    }
}
