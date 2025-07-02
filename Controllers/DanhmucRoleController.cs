﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucRoleController : ControllerBase
    {
        public readonly IDanhmucRoleService _danhmucRoleService;
        public DanhmucRoleController(IDanhmucRoleService danhmucRoleService)
        {
            _danhmucRoleService = danhmucRoleService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucRoleService.GetAll();
            return Ok(query);
        }
        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhMucRole> reponse)
        {
            var query = await _danhmucRoleService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }
        [HttpPost("DeleteMultipale")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhMucRole> reponse)
        {
            var query = await _danhmucRoleService.DeleteMultiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
    }
}
