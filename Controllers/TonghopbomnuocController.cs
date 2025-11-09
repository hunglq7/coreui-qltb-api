using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.TonghopBomnuc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopbomnuocController : ControllerBase
    {
        private readonly ITonghopbomnuocService _service;
        public TonghopbomnuocController(ITonghopbomnuocService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TonghopbomnuocCreateRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Request body is required.");
                }

                var result = await _service.Add(request);
                if (!result)
                {
                    return BadRequest("Create failed.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] TonghopbomnuocUpdateRequest request)
        {
            try
            {
                if (request == null || request.Id <= 0)
                {
                    return BadRequest("Invalid request.");
                }

                var result = await _service.Update(request);
                if (!result)
                {
                    return NotFound("Item not found or update failed.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id.");
                }

                var result = await _service.Delete(id);
                if (!result)
                {
                    return NotFound("Item not found or delete failed.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id.");
                }

                var result = await _service.GetById(id);
                if (result == null || result.Id == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetailById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id.");
                }

                var result = await _service.getDatailById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopbomnuocPagingRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Query parameters are required.");
                }

                var result = await _service.GetAllPaging(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("sumTonghopbomnuoc")]
        public async Task<IActionResult> Sum()
        {
            try
            {
                var result = await _service.Sum();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("TonghopbomnuocController is working!");
        }
    }
} 