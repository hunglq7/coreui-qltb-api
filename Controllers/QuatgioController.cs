using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;
using WebApi.Common;
using WebApi.Models.Quatgio;
using WebApi.Services;
using System.Net.Http;
using System.Net.Http.Headers;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuatgioController : ControllerBase
    {
        private readonly IQuatgioService _quatgioService;
        public QuatgioController(IQuatgioService quatgioService)
        {
            _quatgioService = quatgioService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] QuatgioCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var count = await _quatgioService.Create(request);
            return Ok(count);
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] QuatgioUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var count=await _quatgioService.Update(request);
            return Ok(count);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageQuatgioPagingRequest request)
        {
            var quatgios = await _quatgioService.GetAllPaging(request);
            return Ok(quatgios);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var query = await _quatgioService.GetById(Id);
            return Ok(query);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _quatgioService.Delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("ExportXls")]
        public async Task<IActionResult> ExportXls([FromQuery] string keyword)
        {
            try
            {
                var fileName = string.Concat("Quatgio_" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ".xlsx");
                var folderName = Path.Combine("wwwroot", "Reports", "Quatgio");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);             
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.                   
                   
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    var dbPath = "/Reports/Quatgio/" + fileName;
                    var data = _quatgioService.GetList(keyword).ToList();
                    await ReportHelper.GenerateXls(data, fullPath);
                  
                    return Ok(new { dbPath });
                }
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi máy chủ nội bộ: {ex}");
            }
        }

     
    }
}
