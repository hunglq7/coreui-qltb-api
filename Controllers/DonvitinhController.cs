using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonvitinhController : ControllerBase
    {
        private readonly IDonvitinhService _donvitinhService;
        public DonvitinhController(IDonvitinhService donvitinhService)
        {
            _donvitinhService = donvitinhService;
        }

        [HttpGet]
        public async Task<ActionResult> GetDonvitinh()
        {
            var donvitinh = await _donvitinhService.GetDonvitinh();
            return Ok(donvitinh);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] DonViTinh request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _donvitinhService.Add(request);
            return Ok();
        }
        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<DonViTinh> donvitinh)
        {
            var donvitinhs = await _donvitinhService.UpdateMultipleDonvitinh(donvitinh);
            if (donvitinhs.Count==0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(donvitinhs.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<DonViTinh> donvitinh)
        {
            var donvitinhs = await _donvitinhService.DeleteMutipleDonvitinh(donvitinh);
            if (donvitinhs.Count==0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(donvitinhs.Count);
        }
    }
}
