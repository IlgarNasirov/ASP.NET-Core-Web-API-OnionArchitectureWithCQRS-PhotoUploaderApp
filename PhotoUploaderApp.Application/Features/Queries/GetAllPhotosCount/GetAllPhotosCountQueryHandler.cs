using MediatR;
using PhotoUploaderApp.Application.Interfaces.Repositories;

namespace PhotoUploaderApp.Application.Features.Queries.GetAllPhotosCount
{
    public class GetAllPhotosCountQueryHandler: IRequestHandler<GetAllPhotosCountQueryRequest, GetAllPhotosCountQueryResponse>
    {
        private readonly IPhotoRepository _photoRepository;
        public GetAllPhotosCountQueryHandler(IPhotoRepository photoRepository)
        {
            _photoRepository= photoRepository;
        }
        public async Task<GetAllPhotosCountQueryResponse> Handle(GetAllPhotosCountQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _photoRepository.GetAllPhotosCount();
            return new GetAllPhotosCountQueryResponse { Count = result };
        }
    }
}