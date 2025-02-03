using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Tonghoptoitruc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghoptoitrucController : ControllerBase
    {
        private readonly ITonghoptoitrucService _service;
        public TonghoptoitrucController(ITonghoptoitrucService service)
        {
            service = _service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TonghoptoitrucCreateRequest request) {
            var query = await _service.Create(request);
            return Ok(query);
        }
        [HttpPut]
        public async Task<IActionResult> Update(TonghoptoitrucUpdateRequest request)
        {
            var query = await _service.Update(request);
            return Ok(query);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = await _service.Delete(id);
            return Ok(query);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = await _service.GetById(id);
            return Ok(query);

        }
      

    }
}
