using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryWithProductsController : ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public CategoryWithProductsController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet("{restaurantId}")]
        public async Task<IEnumerable<CategoryWithProducts>> Get(int restaurantId)
        {
            return await _domain.GetCategoriesWithProductsFromRestaurant(restaurantId);
        }
    }
}
