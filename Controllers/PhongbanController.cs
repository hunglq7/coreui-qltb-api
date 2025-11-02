using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Phongban;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongbanController : ControllerBase
    {
        private readonly IPhongbanService _phongbanService;
        private readonly ThietbiDbContext _thietbiDbContext;
        public PhongbanController(IPhongbanService phongbanService, ThietbiDbContext thietbiDbContext)
        {
            _phongbanService = phongbanService;
            _thietbiDbContext = thietbiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetPhongban()
        {
            var phongban = await _phongbanService.GetPhongban();
            return Ok(phongban);

        }
        //[HttpPost]
        //public async Task<ActionResult> CreatePhongban(PhongbanCreateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var phongban = await _phongbanService.CreatePhongban(request);
        //    return Ok(phongban);
        //}
        [HttpPost("delete")]
        public async Task<IActionResult> DeletePhongban(PhongbanVm phongban)
        {
            var Result = await _phongbanService.Delete(phongban);
            if (Result == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<PhongBan> phongBan)
        {

            var response = await _phongbanService.UpdateMultiple(phongBan);
            if (response.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(response.Count);
        }
        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<PhongBan> phongBan)
        {
            var response = await _phongbanService.DeleteMutiple(phongBan);
            if (response.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(response.Count);

        }


        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PhongBan request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _phongbanService.Add(request);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] PhongBan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _phongbanService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _phongbanService.Delete(id);
            return Ok();
        }
    }
}
