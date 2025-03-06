﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Models.ThongsoQuatgio;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsoquatgioController : ControllerBase
    {
        private IThongsoquatgioService _thongsoquatgioService;
        public ThongsoquatgioController(IThongsoquatgioService thongsoquatgioService)
        {
            _thongsoquatgioService = thongsoquatgioService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _thongsoquatgioService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsoquatgioPagingRequest request)
        {
            var query = await _thongsoquatgioService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongsoQuatgio request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsoquatgioService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _thongsoquatgioService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _thongsoquatgioService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongsoQuatgio request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsoquatgioService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsoquatgioService.Delete(id);
            return Ok();
        }
    }
}
