using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public OrderController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }


        [HttpPost]
        public OrderShowDTO Get(OrderCreateDTO order)
        {
            return _mapper.Map<OrderShowDTO>(_domain.GetOrder(_mapper.Map<Order>(order)));
        }

    }
}
