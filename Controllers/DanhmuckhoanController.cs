using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucKhoanController : ControllerBase
    {
        private readonly IDanhmucKhoanService _danhmucKhoanService;

        public DanhmucKhoanController(IDanhmucKhoanService danhmucKhoanService)
        {
            _danhmucKhoanService = danhmucKhoanService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucKhoanService.GetAll();
            return Ok(query);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhMucKhoan> response)
        {
            var result = await _danhmucKhoanService.UpdateMultiple(response);
            if (result.Count == 0)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Count);
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhMucKhoan> response)
        {
            var result = await _danhmucKhoanService.DeleteMultiple(response);
            if (result.Count == 0)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Count);
        }
    }
}