using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkyquatgioController : ControllerBase
    {
        private readonly INhatkyquatgioService _nhatkyquatgioService;
        public NhatkyquatgioController( INhatkyquatgioService nhatkyquatgioService)
        {
            _nhatkyquatgioService = nhatkyquatgioService;
            
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _nhatkyquatgioService.GetAll();
            return Ok(query);
        }
        [HttpGet("DatailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _nhatkyquatgioService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<NhatKyQuatGio> request)
        {
            var query = await _nhatkyquatgioService.UpdateMultiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<NhatKyQuatGio> request)
        {
            var query = await _nhatkyquatgioService.DeleteMutiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query.Count);
        }


        [HttpPost]
        public async Task<ActionResult> Add([FromBody] NhatKyQuatGio request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _nhatkyquatgioService.Add(request);
            return Ok();
        }
    }
}
