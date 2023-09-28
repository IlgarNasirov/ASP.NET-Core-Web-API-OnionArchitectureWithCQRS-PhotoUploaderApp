using MediatR;
using PhotoUploaderApp.Application.Interfaces.Repositories;

namespace PhotoUploaderApp.Application.Features.Queries.GetPhoto
{
    public class GetPhotoQueryHandler: IRequestHandler<GetPhotoQueryRequest, GetPhotoQueryResponse?>
    {
        private readonly IPhotoRepository _photoRepository;
        public GetPhotoQueryHandler(IPhotoRepository photoRepository)
        {
            _photoRepository= photoRepository;
        }
        public async Task<GetPhotoQueryResponse?>Handle(GetPhotoQueryRequest getPhotoQueryRequest, CancellationToken cancellationToken)
        {
            var result = await _photoRepository.GetPhoto(getPhotoQueryRequest.ShortId);
            if (result == null)
                return null;
            return new GetPhotoQueryResponse { AddedDate = result.AddedDate, DownloadCount = result.DownloadCount, Url = result.Url };
        }
    }
}
