using AutoMapper;
using FiveMeals.Domain;
using FiveMeals.Domain.Model;
using FiveMeals.WebAPI.Model.Table;
using FiveMeals.WebAPI.Model.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMeals.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private IDomain _domain;
        private readonly IMapper _mapper;

        public TableController(IDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        public IEnumerable<ShowTableDTO> Get()
        {
            return _mapper.Map<IEnumerable<ShowTableDTO>>(_domain.GetAllTables());
            
        }
        [HttpGet("{id}")]
        public ShowTableDTO Get(int id)
        {
            return _mapper.Map<ShowTableDTO>(_domain.GetTable(id));
        }

        [HttpPost]
        public void Create(CreateTableDTO tableIn)
        {
            _domain.CreateTable(_mapper.Map<Table>(tableIn));
        }

    
    }
}
