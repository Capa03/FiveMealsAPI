using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Favorite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public FavoriteController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet]

        public IEnumerable<ShowFavoriteDTO?> Get(String userEmail)
        {
            return _mapper.Map<IEnumerable<ShowFavoriteDTO?>>(_domain.GetFavorites(userEmail));
        }

        [HttpPost]
        public void Create(CreateFavoriteDTO favoriteIn)
        {
            _domain.checkFavorite(_mapper.Map<Favorite>(favoriteIn));
        }

    }
}
