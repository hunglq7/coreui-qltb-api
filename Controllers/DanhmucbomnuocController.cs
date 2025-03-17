using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucbomnuocController : ControllerBase
    {
        public readonly IDanhmucbomnuocService _danhmucbomnuocService;
        public readonly ThietbiDbContext _dbContext;
        public DanhmucbomnuocController( IDanhmucbomnuocService danhmucbomnuocService, ThietbiDbContext dbContext)
        {
            _danhmucbomnuocService = danhmucbomnuocService;
            _dbContext = dbContext;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucbomnuocService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucBomnuoc> reponse)
        {

            var query = await _danhmucbomnuocService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucBomnuoc> reponse)
        {
            var query = await _danhmucbomnuocService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }

        [HttpPost("UploadExcelFile")]
        public async Task<IActionResult> UploadExcelFile([FromForm] IFormFile file)
        {
            try {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if(file==null || file.Length==0)
                {
                    BadRequest("No file Upload");
                }
                var uploadFolder = $"{Directory.GetCurrentDirectory()}\\Uploads";
                if(Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var filePath = Path.Combine(uploadFolder, file.FileName);
                using(var stream=new FileStream(filePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                       
                        do
                        {
                            bool isHeaderSkipped = false;
                            if (!isHeaderSkipped)
                            {
                                isHeaderSkipped = true;
                                continue;
                            }
                            while (reader.Read())
                            {
                                DanhmucBomnuoc dmBomNuoc = new DanhmucBomnuoc();
                                dmBomNuoc.TenThietBi = reader.GetValue(1).ToString();
                                dmBomNuoc.LoaiThietBi = reader.GetValue(2).ToString();

                                _dbContext.Add(dmBomNuoc);
                               await  _dbContext.SaveChangesAsync();
                            }
                        } while (reader.NextResult());

                       
                    }
                   
                }
                return Ok("Thêm bản ghi thành công");
            }
            catch(Exception ex)
            {
                StatusCode(5000, ex.Message);
            }
            return BadRequest("Thêm thất bại");
        }

    }
}
