using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoUploaderApp.Application.Features.Commands.AddPhoto;
using PhotoUploaderApp.Application.Features.Commands.DownloadPhoto;
using PhotoUploaderApp.Application.Features.Queries.GetAllPhotosCount;
using PhotoUploaderApp.Application.Features.Queries.GetPhoto;
using PhotoUploaderApp.Application.Features.Queries.GetRandomPhoto;
using PhotoUploaderApp.Application.Features.Queries.GetThePhotosOfToday;

namespace PhotoUploaderApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        IMediator _mediator;
        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddPhoto")]
        public async Task<IActionResult> AddPhoto([FromForm]AddPhotoCommandRequest addPhotoCommandRequest)
        {
            var result=await _mediator.Send(addPhotoCommandRequest);
            if(result == null)
            {
                return BadRequest("This file type doesn't supported.");
            }

            return Ok(result);
        }

        [HttpGet("DownloadPhoto")]
        public async Task<IActionResult> DownloadPhoto([FromQuery]DownloadPhotoCommandRequest downloadPhotoCommandRequest)
        {
            var result = await _mediator.Send(downloadPhotoCommandRequest);
            if (result == null)
            {
                return NotFound();
            }
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", result.URL!), "application/image", result.URL!);
        }

        [HttpGet("AllPhotosCount")]
        public async Task<IActionResult> AllPhotosCount([FromQuery]GetAllPhotosCountQueryRequest getAllPhotosCountQueryRequest)
        {
            return Ok(await _mediator.Send(getAllPhotosCountQueryRequest));
        }

        [HttpGet("Photo")]
        public async Task<IActionResult> Photo([FromQuery]GetPhotoQueryRequest getPhotoQueryRequest)
        {
            var result = await _mediator.Send(getPhotoQueryRequest);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("RandomPhoto")]
        public async Task<IActionResult> RandomPhoto([FromQuery] GetRandomPhotoQueryRequest getRandomPhotoQueryRequest)
        {
            return Ok(await _mediator.Send(getRandomPhotoQueryRequest));
        }

        [HttpGet("ThePhotosOfToday")]
        public async Task<IActionResult> ThePhotosOfToday([FromQuery] GetThePhotosOfTodayQueryRequest getThePhotosOfTodayQueryRequest)
        {
            return Ok(await _mediator.Send(getThePhotosOfTodayQueryRequest));
        }
    }
}
