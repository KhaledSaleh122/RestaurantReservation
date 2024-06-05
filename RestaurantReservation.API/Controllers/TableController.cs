using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Table;
using RestaurantReservation.Db;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "Manager")]
    [Route("api/restaurants/tables")]
    public class TableController : Controller
    {
        private readonly TableRepository _repository;
        private readonly RestaurantRepository restaurantRepository;
        private readonly IMapper _mapper;

        public TableController(TableRepository repository, RestaurantRepository restaurantRepository)
        {
            _repository = repository;
            this.restaurantRepository = restaurantRepository;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Table, TableDto>();
                cfg.CreateMap<TableCreateDto, Table>();
            });
            _mapper = configuration.CreateMapper();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> GetTables()
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var tables = await _repository.GetAllTables(restaurantId);
            return Ok(_mapper.Map<IEnumerable<TableDto>>(tables));
        }

        [HttpGet("{tableId}")]
        public async Task<ActionResult<TableDto>> GetTable(int tableId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await _repository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TableDto>(table));
        }

        [HttpPost]
        public async Task<ActionResult<TableDto>> CreateTable([FromBody] TableCreateDto table)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var finialTable = _mapper.Map<Table>(table);
            finialTable.RestaurantId = restaurantId;
            var tableInfo = await _repository.CreateTableAsync(finialTable);
            return Ok(_mapper.Map<TableDto>(tableInfo));
        }

        [HttpPut("{tableId}")]
        public async Task<ActionResult> UpdateTable(int tableId, [FromBody] TableCreateDto tableinfo)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await _repository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }
            _mapper.Map(tableinfo, table);
            await _repository.UpdateTableAsync(table);
            return Ok();
        }

        [HttpDelete("{tableId}")]
        public async Task<ActionResult> DeleteTable(int tableId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await _repository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }
            await _repository.DeleteTableAsync(tableId);
            return Ok();
        }

    }
}
