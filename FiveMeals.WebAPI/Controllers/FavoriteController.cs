using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Favorite;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
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

        public IEnumerable<ShowFavoriteDTO>? Get(long userId)
        {
            return _mapper.Map<IEnumerable<ShowFavoriteDTO>>(_domain.GetFavorites(userId));
        }

        [HttpPost]
        public void Create(IEnumerable<CreateFavoriteDTO> favoriteIn, long userId)
        {
            _domain.insertFavorite(_mapper.Map<IEnumerable<Favorite>>(favoriteIn),userId);
        }

        [HttpDelete]
        public void Delete(long favorites,long userId)
        {
            _domain.deleteFavorite(favorites,userId);
        }
    }
}
