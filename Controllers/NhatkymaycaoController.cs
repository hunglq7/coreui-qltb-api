﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkymaycaoController : ControllerBase
    {
        public readonly INhatkyMayCaoService _nhatkyMayCaoService;
        public NhatkymaycaoController(INhatkyMayCaoService nhatkyMayCaoService)
        {
            _nhatkyMayCaoService = nhatkyMayCaoService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _nhatkyMayCaoService.GetAll();
            return Ok(query);
        }
        [HttpGet("DatailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _nhatkyMayCaoService.GetDetailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<NhatKyMayCao> request)
        {
            var query = await _nhatkyMayCaoService.UpdateMultiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<NhatKyMayCao> request)
        {
            var query = await _nhatkyMayCaoService.DeleteMultiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query.Count);
        }
    }
}
