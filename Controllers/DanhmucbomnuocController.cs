using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucbomnuocController : ControllerBase
    {
        public readonly IDanhmucbomnuocService _danhmucbomnuocService;
        public DanhmucbomnuocController( IDanhmucbomnuocService danhmucbomnuocService)
        {
            _danhmucbomnuocService = danhmucbomnuocService;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucbomnuocService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucBomnuoc> reponse)
        {

            var query = await _danhmucbomnuocService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucBomnuoc> reponse)
        {
            var query = await _danhmucbomnuocService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}
