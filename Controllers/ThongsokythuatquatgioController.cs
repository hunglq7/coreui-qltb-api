using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entites;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
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
           _thongsokythuatquatgioService=thongsokythuatquatgioService;
            
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ThongsokythuatQuatgio response)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
var count=await _thongsokythuatquatgioService.Create(response);
return Ok(count);

        }
    }
}