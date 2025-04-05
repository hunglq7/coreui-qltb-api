using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Neo.TongHopNeo;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopneoController : ControllerBase
    {
        private readonly ITonghopneoService _tonghopneoService;

        public TonghopneoController(ITonghopneoService tonghopneoService)
        {
            _tonghopneoService = tonghopneoService;
        }

        [HttpGet("paging")]
        public async Task<ActionResult<PagedResult<TongHopNeoVm>>> GetAllPaging([FromQuery] TongHopNeoPagingRequest request)
        {
            var result = await _tonghopneoService.GetAllPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TongHopNeo>> GetById(int id)
        {
            var result = await _tonghopneoService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<List<TongHopNeoVm>>> GetDetailById(int id)
        {
            var result = await _tonghopneoService.GetDetailById(id);
            return Ok(result);
        }

        [HttpGet("sum")]
        public async Task<ActionResult<int>> GetSum()
        {
            var result = await _tonghopneoService.Sum();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] TongHopNeo request)
        {
            var result = await _tonghopneoService.Add(request);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody] TongHopNeo request)
        {
            var result = await _tonghopneoService.Update(request);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _tonghopneoService.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}