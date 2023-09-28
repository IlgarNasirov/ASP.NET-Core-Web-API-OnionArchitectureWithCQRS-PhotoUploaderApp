using MediatR;

namespace PhotoUploaderApp.Application.Features.Commands.DownloadPhoto
{
    public class DownloadPhotoCommandRequest:IRequest<DownloadPhotoCommandResponse?>
    {
        public string ShortId { get; set; } = null!;
    }
}
