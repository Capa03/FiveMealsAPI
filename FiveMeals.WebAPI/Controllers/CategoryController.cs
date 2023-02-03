using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController :ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public CategoryController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        //Get all 
        [HttpGet]
        public IEnumerable<ShowCategoryDTO>? Get()
        {
            return _mapper.Map<IEnumerable<ShowCategoryDTO>>(_domain.GetAllCategories());
        }

        //Get all from restaurantId
        [HttpGet("{restaurantId}")]
        public async Task<IEnumerable<ShowCategoryDTO?>> Get(int restaurantId)
        {
            return _mapper.Map<IEnumerable<ShowCategoryDTO>>(await _domain.GetCategoriesFromRestaurant(restaurantId));
        }

        [HttpPost]
        public void Create(CreateCategoryDTO CategoryIn)
        {
            _domain.CreateCategory(_mapper.Map<Category>(CategoryIn));
        }
    }
}
