namespace PhotoUploaderApp.Application.Features.Queries.GetRandomPhoto
{
    public class GetRandomPhotoQueryResponse
    {
        public string Url { get; set; } = null!;
        public DateTime AddedDate { get; set; }
        public int DownloadCount { get; set; }
    }
}
