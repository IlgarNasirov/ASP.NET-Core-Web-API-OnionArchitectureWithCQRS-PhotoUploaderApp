using MediatR;
using PhotoUploaderApp.Application.Interfaces.Repositories;

namespace PhotoUploaderApp.Application.Features.Queries.GetThePhotosOfToday
{
    public class GetThePhotosOfTodayQueryHandler:IRequestHandler<GetThePhotosOfTodayQueryRequest, List<GetThePhotosOfTodayQueryResponse>>
    {
        private readonly IPhotoRepository _photoRepository;
        public GetThePhotosOfTodayQueryHandler(IPhotoRepository photoRepository)
        {
           _photoRepository = photoRepository;
        }
        public async Task<List<GetThePhotosOfTodayQueryResponse>> Handle(GetThePhotosOfTodayQueryRequest getThePhotosOfTodayQueryRequest, CancellationToken cancellationToken)
        {
            var result = await _photoRepository.GetThePhotosOfToday();
            return (from r in result select new GetThePhotosOfTodayQueryResponse { DownloadCount = r.DownloadCount, Url = r.Url }).ToList();
        }
    }
}