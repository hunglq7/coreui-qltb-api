using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucAptomatKhoidongtuController : ControllerBase
    {
        public readonly IDanhmucAptomatKhoidongtuService _danhmucAptomatKhoidongtuService;
        public DanhmucAptomatKhoidongtuController(IDanhmucAptomatKhoidongtuService danhmucAptomatKhoidongtuService)
        {
            _danhmucAptomatKhoidongtuService = danhmucAptomatKhoidongtuService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucAptomatKhoidongtuService.GetAll();
            return Ok(query);
        }

        [HttpPost("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhmucAptomatKhoidongtu> response)
        {
            var query = await _danhmucAptomatKhoidongtuService.UpdateMultiple(response);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucAptomatKhoidongtu> response)
        {
            var query = await _danhmucAptomatKhoidongtuService.DeleteMultiple(response);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
    }
}