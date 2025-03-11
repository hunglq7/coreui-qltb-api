using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkybomnuocController : ControllerBase
    {
        public readonly INhatkybomnuocService _nhatkybomnuocService;
        public NhatkybomnuocController( INhatkybomnuocService nhatkybomnuocService)
        {
            _nhatkybomnuocService = nhatkybomnuocService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _nhatkybomnuocService.GetAll();
            return Ok(query);
        }
        [HttpGet("DatailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _nhatkybomnuocService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<NhatKyBomNuoc> request)
        {
            var query = await _nhatkybomnuocService.UpdateMultiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<NhatKyBomNuoc> request)
        {
            var query = await _nhatkybomnuocService.DeleteMutiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query.Count);
        }
    }
}
