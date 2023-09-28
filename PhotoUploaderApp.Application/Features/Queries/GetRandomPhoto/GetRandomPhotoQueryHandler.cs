using MediatR;
using PhotoUploaderApp.Application.Interfaces.Repositories;

namespace PhotoUploaderApp.Application.Features.Queries.GetRandomPhoto
{
    public class GetRandomPhotoQueryHandler:IRequestHandler<GetRandomPhotoQueryRequest, GetRandomPhotoQueryResponse>
    {
        private readonly IPhotoRepository _photoRepository;
        public GetRandomPhotoQueryHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<GetRandomPhotoQueryResponse>Handle(GetRandomPhotoQueryRequest getRandomPhotoQueryRequest, CancellationToken cancellationToken)
        {
            var result = await _photoRepository.GetRandomPhoto();
            return new GetRandomPhotoQueryResponse { AddedDate = result.AddedDate, DownloadCount = result.DownloadCount, Url = result.Url };
        }
    }
}
