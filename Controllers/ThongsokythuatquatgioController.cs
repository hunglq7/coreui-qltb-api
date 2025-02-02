using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entites;
using Api.Models.ThongsokythuatQuatgio;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Quatgio;
using WebApi.Models.ThongsokythuatQuatgio;
using WebApi.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongsokythuatquatgioController : ControllerBase
    {
        private readonly IThongsokythuatquatgioService _thongsokythuatquatgioService;
        public ThongsokythuatquatgioController(IThongsokythuatquatgioService thongsokythuatquatgioService)
        {
            _thongsokythuatquatgioService = thongsokythuatquatgioService;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ThongsokythuatquatgioCreateRequest response)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var count = await _thongsokythuatquatgioService.Create(response);
            return Ok(count);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ThongsokythuatquatgioUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var count = await _thongsokythuatquatgioService.Update(request);
            return Ok(count);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManagerThongsokythuatquatgioPagingRequest request)
        {
            var items = await _thongsokythuatquatgioService.GetAllPaging(request);
            return Ok(items);
        }

   

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var query = await _thongsokythuatquatgioService.GetById(Id);
            return Ok(query);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsokythuatquatgioService.Delete(id);
            return Ok();
        }
    }
}