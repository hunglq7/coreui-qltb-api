using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.TonghopRole;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopRoleController : ControllerBase
    {
        public readonly ITonghopRoleService _tonghopRoleService;
        public TonghopRoleController(ITonghopRoleService tonghopRoleService)
        {
            _tonghopRoleService = tonghopRoleService;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TongHopRole request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopRoleService.Add(request);
            return Ok();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopRoleService.GetById(Id);
            return Ok(entity);
        }
        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopRoleService.getDatailById(Id);
            return Ok(entity);
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TongHopRole request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopRoleService.Update(request);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopRoleService.Delete(id);
            return Ok();
        }
        [HttpGet("paging")]
        public async Task<ActionResult> GetPaging([FromQuery] TonghopRolePagingRequest request)
        {
            var entities = await _tonghopRoleService.GetAllPaging(request);
            return Ok(entities);
        }
        [HttpGet("sum")]
        public async Task<ActionResult> Sum()
        {
            var sum = await _tonghopRoleService.Sum();
            return Ok(sum);
        }
    }
}
