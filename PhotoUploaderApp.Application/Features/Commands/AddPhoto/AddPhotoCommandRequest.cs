using MediatR;
using Microsoft.AspNetCore.Http;

namespace PhotoUploaderApp.Application.Features.Commands.AddPhoto
{
    public class AddPhotoCommandRequest:IRequest<AddPhotoCommandResponse?>
    {
        public IFormFile Photo { get; set; } = null!;
    }
}