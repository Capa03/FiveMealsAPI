using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.WebAPI.Model.Table;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableFromRestaurantController : ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public TableFromRestaurantController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet("{ResId}")]
        public IEnumerable<int> Get (int ResId)
        {
            return _domain.GetTableFromRestaurant(ResId);
        }
        
    }
}
