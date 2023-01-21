using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using FiveMeals.WebAPI.Model.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductController
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public ProductController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        //Get all
        [HttpGet]
        public IEnumerable<ShowProductDTO>? Get()
        {
            return _mapper.Map<IEnumerable<ShowProductDTO>>(_domain.GetAllProducts());
        }

        //Get from Restaurant and category
        [HttpGet("{categoryId}")]
        public IEnumerable<ShowProductDTO>? Get(int categoryId)
        {
            return _mapper.Map<IEnumerable<ShowProductDTO>>(_domain.GetProductsFromCategoryId(categoryId));
        }

        [HttpPost]
        public void Create(CreateProductDTO ProductIn)
        {
            _domain.CreateProduct(_mapper.Map<Product>(ProductIn));

        }

    }
}
