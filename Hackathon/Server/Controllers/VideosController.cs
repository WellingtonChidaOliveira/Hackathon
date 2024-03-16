using Hackathon.Domain.Videos;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        public VideosController()
        {
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Video video)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtRoute("Get",null);
        }

    }
}
