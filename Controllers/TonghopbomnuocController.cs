using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.TonghopBomnuc;
using WebApi.Models.Tonghopquatgio;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopbomnuocController : ControllerBase
    {
        public readonly ITonghopbomnuocService _tonghopbomnuocService;
        public TonghopbomnuocController(ITonghopbomnuocService tonghopbomnuocService)
        {
            _tonghopbomnuocService = tonghopbomnuocService; 
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TongHopBomNuoc request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopbomnuocService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopbomnuocService.GetById(Id);
            return Ok(entity);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopbomnuocService.getDatailById(Id);
            return Ok(entity);
        }
        [HttpGet("sum")]

        public async Task<ActionResult> Sum()
        {
            var query = await _tonghopbomnuocService.Sum();
            return Ok(query);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TongHopBomNuoc request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopbomnuocService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopbomnuocService.Delete(id);
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopbomnuocPagingRequest request)
        {
            var query = await _tonghopbomnuocService.GetAllPaging(request);
            return Ok(query);

        }
    }
}
