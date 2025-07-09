using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucBienapController : ControllerBase
    {
        public readonly IDanhmucBienApService _danhmucBienApService;
        public DanhmucBienapController(IDanhmucBienApService danhmucBienApService)
        {
            _danhmucBienApService = danhmucBienApService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucBienApService.GetAll();
            return Ok(query);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhmucBienap> response)
        {
            var query = await _danhmucBienApService.UpdateMultiple(response);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucBienap> response)
        {
            var query = await _danhmucBienApService.DeleteMultiple(response);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
    }
}