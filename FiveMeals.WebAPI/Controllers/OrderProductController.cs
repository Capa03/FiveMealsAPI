using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Category;
using FiveMeals.WebAPI.Model.OrderProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
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
        public IEnumerable<OrderProductShowDTO>? Get(long orderId)
        {
            return _mapper.Map<IEnumerable<OrderProductShowDTO>>(_domain.getOrderProducts(orderId));
        }

        [HttpPost]
        public void Create(IEnumerable< OrderProductCreateDTO> orderProductsIn)
        {
            _domain.insertOrderProducts(_mapper.Map<IEnumerable<OrderProduct>> (orderProductsIn));
        }


        [HttpDelete]
        public void Delete(IEnumerable<long> orderProductsIn)
        {
            _domain.deleteOrderProducts(orderProductsIn);
        }

        [HttpPatch]
        public void Patch(IEnumerable<OrderProductPatchDTO> orderProductsIn)
        {
            _domain.updateOrderProducts(_mapper.Map<IEnumerable<OrderProduct>>(orderProductsIn));
        }
    }
}
