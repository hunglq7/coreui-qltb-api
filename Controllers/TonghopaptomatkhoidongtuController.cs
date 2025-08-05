using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu;
using WebApi.Services;
using WebApi.Data.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TonghopaptomatkhoidongtuController : ControllerBase
    {
        private readonly ITonghopaptomatkhoidongtuService _tonghopaptomatkhoidongtuService;

        public TonghopaptomatkhoidongtuController(ITonghopaptomatkhoidongtuService tonghopaptomatkhoidongtuService)
        {
            _tonghopaptomatkhoidongtuService = tonghopaptomatkhoidongtuService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopaptomatkhoidongduPagingRequest request)
        {
            var query = await _tonghopaptomatkhoidongtuService.GetAllPaging(request);
            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TongHopAptomatKhoidongtu request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopaptomatkhoidongtuService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _tonghopaptomatkhoidongtuService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _tonghopaptomatkhoidongtuService.GetDataiById(Id);
            return Ok(items);
        }

        [HttpGet("Sum")]
        public async Task<ActionResult> GetSum()
        {
            var sum = await _tonghopaptomatkhoidongtuService.Sum();
            return Ok(sum);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TongHopAptomatKhoidongtu request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopaptomatkhoidongtuService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopaptomatkhoidongtuService.Delete(id);
            return Ok();
        }
    }
}