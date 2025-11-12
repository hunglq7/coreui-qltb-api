
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Tonghopquatgio;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopquatgioController : ControllerBase
    {
        private readonly ITonghopquatgioService _tonghopquatgioService;
        public TonghopquatgioController(ITonghopquatgioService tonghopquatgioService)
        {
            _tonghopquatgioService = tonghopquatgioService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Add([FromBody] TonghopQuatgio request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopquatgioService.AddTonghopquatgio(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopquatgioService.GetById(Id);
            return Ok(entity);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopquatgioService.getDatailById(Id);
            return Ok(entity);
        }
        [HttpGet("sumTonghopquatgio")]

        public async Task<ActionResult> Sum()
        {
            var query = await _tonghopquatgioService.SumTonghopquatgio();
            return Ok(query);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TonghopQuatgio request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopquatgioService.UpdateTonghopquatgio(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopquatgioService.DeleteTonghopquatgio(id);
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopquatgioPagingRequest request)
        {
            var query = await _tonghopquatgioService.GetAllPaging(request);
            return Ok(query);

        }
        [HttpGet("getAll")]
        public async Task<ActionResult> GetQuatgio()
        {
            var quatgio = await _tonghopquatgioService.GetQuatgio();
            return Ok(quatgio);
        }

        [HttpPost("DeleteMultipale")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<TonghopQuatgio> reponse)
        {
            var query = await _tonghopquatgioService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }

    }
}
