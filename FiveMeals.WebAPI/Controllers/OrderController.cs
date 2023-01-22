using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Order;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
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


        [HttpGet("{tableId}")]
        public OrderShowDTO Get(long tableId)
        {
            return _mapper.Map<OrderShowDTO>(_domain.GetOrder(tableId));
        }

        [HttpPost]
        public void Create(OrderCreateDTO order)
        {
            _domain.insertOrder(_mapper.Map<Order>(order));
        }

    }
}
