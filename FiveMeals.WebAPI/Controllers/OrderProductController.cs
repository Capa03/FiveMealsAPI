using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using FiveMeals.WebAPI.Model.OrderProduct;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public OrderProductController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<OrderProductShowDTO>? Get(long tableId)
        {
            return _mapper.Map<IEnumerable<OrderProductShowDTO>>(_domain.getOrderProducts(tableId));
        }

        [HttpPost]
        public void Create(IEnumerable< OrderProductCreateDTO> orderProductsIn)
        {
            _domain.insertOrderProducts(_mapper.Map<IEnumerable<OrderProduct>> (orderProductsIn), 1);
        }

        [HttpDelete]
        public void Delete(IEnumerable<long> orderProductsIn)
        {
            _domain.deleteOrderProducts(orderProductsIn,1);
        }
    }
}
