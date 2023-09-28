using MediatR;

namespace PhotoUploaderApp.Application.Features.Queries.GetPhoto
{
    public class GetPhotoQueryRequest:IRequest<GetPhotoQueryResponse?>
    {
        public string ShortId { get; set; } = null!;
    }
}
