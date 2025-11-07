using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucquatgioController : ControllerBase
    {
        private readonly IDanhmucquatgioService _danhmucquatgioService;
        public DanhmucquatgioController( IDanhmucquatgioService danhmucquatgioService)
        {
            _danhmucquatgioService = danhmucquatgioService;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucquatgioService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucQuatgio> reponse)
        {

            var query = await _danhmucquatgioService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucQuatgio> reponse)
        {
            var query = await _danhmucquatgioService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}
