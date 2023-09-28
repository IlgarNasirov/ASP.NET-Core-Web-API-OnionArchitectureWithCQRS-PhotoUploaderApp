using MediatR;

namespace PhotoUploaderApp.Application.Features.Queries.GetRandomPhoto
{
    public class GetRandomPhotoQueryRequest:IRequest<GetRandomPhotoQueryResponse>
    {
    }
}
