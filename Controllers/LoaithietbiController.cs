using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaithietbiController : ControllerBase
    {
        private readonly ILoaithietbiService _loaithietbiService;
            public LoaithietbiController(ILoaithietbiService loaithietbiService)
        {
            _loaithietbiService = loaithietbiService;
        }
        [HttpGet]
        public async Task<ActionResult> GetDonvitinh()
        {
            var loaithietbi = await _loaithietbiService.GetLoaithietbi();
            return Ok(loaithietbi);
        }
        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<LoaiThietBi> loaithietbi)
        {
            var loaithietbis = await _loaithietbiService.UpdateMultipleLoaithietbi(loaithietbi);
            if (loaithietbis.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(loaithietbis.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<LoaiThietBi> loaithietbi)
        {
            var loathietbis = await _loaithietbiService.DeleteMutipleLoaithietbi(loaithietbi);
            if (loathietbis.Count==0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(loathietbis.Count);
        }

    }
}
