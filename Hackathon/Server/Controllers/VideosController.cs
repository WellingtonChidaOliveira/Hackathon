using Hackathon.Application.UseCases.DownloadZipVideo;
using Hackathon.Application.UseCases.GetListVideos;
using Hackathon.Application.UseCases.UploadVideos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly ISender _sender;

        public VideosController(ISender sender)
        {
            _sender = sender;
        }

     

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var result = await _sender.Send(new GetListVideosCommmand());
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(UploadVideosCommand command)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sender.Send(command);

            return CreatedAtRoute("Get", result);
        }

        [HttpPost("/download")]
        public async Task<IActionResult> Download(DowloadZipVideoCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sender.Send(command);

            return CreatedAtRoute("Get", result);
        }

    }
}
