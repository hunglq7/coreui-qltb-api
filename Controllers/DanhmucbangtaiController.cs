using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucbangtaiController : ControllerBase
    {
        private readonly IDanhmucbangtaiService _danhmucbangtaiService;
        public DanhmucbangtaiController(IDanhmucbangtaiService danhmucbangtaiService)
        {
            _danhmucbangtaiService = danhmucbangtaiService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DanhmucbangtaiVM>>> GetAll()
        {
            var result = await _danhmucbangtaiService.GetAll();
            return Ok(result);
        }

        [HttpPost("UpdateMultiple")]
        public async Task<ActionResult<ApiResult<int>>> UpdateMultiple([FromBody] List<DanhMucBangTai> response)
        {
            var result = await _danhmucbangtaiService.UpdateMultiple(response);
            return Ok(result);
        }

        [HttpPost("DeleteMutiple")]
        public async Task<ActionResult<ApiResult<int>>> DeleteMutiple([FromBody] List<DanhMucBangTai> response)
        {
            var result = await _danhmucbangtaiService.DeleteMutiple(response);
            return Ok(result);
        }
    }
}