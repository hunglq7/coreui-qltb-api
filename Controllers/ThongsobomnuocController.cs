using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.ThongsoBomnuoc;
using WebApi.Models.ThongsoQuatgio;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsobomnuocController : ControllerBase
    {
        public readonly IThongsobomnuocService _thongsobomnuocService;
        public ThongsobomnuocController( IThongsobomnuocService thongsobomnuocService)
        {
            _thongsobomnuocService = thongsobomnuocService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _thongsobomnuocService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsoBomnuocPagingRequest request)
        {
            var query = await _thongsobomnuocService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongSoBomNuoc request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsobomnuocService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _thongsobomnuocService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _thongsobomnuocService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongSoBomNuoc request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsobomnuocService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsobomnuocService.Delete(id);
            return Ok();
        }
    }
}
