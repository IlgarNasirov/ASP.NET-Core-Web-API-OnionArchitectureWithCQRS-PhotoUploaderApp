using MediatR;

namespace PhotoUploaderApp.Application.Features.Queries.GetThePhotosOfToday
{
    public class GetThePhotosOfTodayQueryRequest:IRequest<List<GetThePhotosOfTodayQueryResponse>>
    {
    }
}
