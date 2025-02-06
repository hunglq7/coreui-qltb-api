using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkyTonghoptoitrucController : ControllerBase
    {
        private readonly INhatkyTonghoptoitrucService _service;
        public NhatkyTonghoptoitrucController(INhatkyTonghoptoitrucService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _service.GetAll();
            return Ok(query);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _service.getDetailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<NhatkyTonghoptoitruc> request)
        {
            var query = await _service.UpdateMultiple(request);
            if (query == null)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<NhatkyTonghoptoitruc> request)
        {
            var query = await _service.DeleteMutiple(request);
            if (query == null)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query);
        }
    }
}
