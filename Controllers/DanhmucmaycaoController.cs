using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucmaycaoController : ControllerBase
    {
        public readonly IDanhmucMayCaoService _danhmucMayCaoService;
        public DanhmucmaycaoController(IDanhmucMayCaoService danhmucMayCaoService)
        {
            _danhmucMayCaoService = danhmucMayCaoService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucMayCaoService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucMayCao> reponse)
        {

            var query = await _danhmucMayCaoService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucMayCao> reponse)
        {
            var query = await _danhmucMayCaoService.DeleteMultiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}

