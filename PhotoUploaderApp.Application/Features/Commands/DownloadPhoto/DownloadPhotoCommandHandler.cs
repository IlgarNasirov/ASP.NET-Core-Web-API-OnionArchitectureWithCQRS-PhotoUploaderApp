using MediatR;
using PhotoUploaderApp.Application.Interfaces.Repositories;

namespace PhotoUploaderApp.Application.Features.Commands.DownloadPhoto
{
    public class DownloadPhotoCommandHandler:IRequestHandler<DownloadPhotoCommandRequest, DownloadPhotoCommandResponse?>
    {
        private readonly IPhotoRepository _photoRepository;
        public DownloadPhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository= photoRepository;
        }

        public async Task<DownloadPhotoCommandResponse?>Handle(DownloadPhotoCommandRequest downloadPhotoCommandRequest, CancellationToken cancellationToken)
        {
            var photo = await _photoRepository.GetPhoto(downloadPhotoCommandRequest.ShortId);
            if (photo == null)
                return null;
            var result=await _photoRepository.DownloadPhoto(photo);
            return new DownloadPhotoCommandResponse { URL = result.Url };
        }
    }
}
