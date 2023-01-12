using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using FiveMeals.WebAPI.Model.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public LoginController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpPost]
        public ShowLoginDTO Create(CreateLoginDTO loginIn)
        {
            return _mapper.Map<ShowLoginDTO>(_domain.CheckLogin(_mapper.Map<Login>(loginIn)));
        }
    }
}
