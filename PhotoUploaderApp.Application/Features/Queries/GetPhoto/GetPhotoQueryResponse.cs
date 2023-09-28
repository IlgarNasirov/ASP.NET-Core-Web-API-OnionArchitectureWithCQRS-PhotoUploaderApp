namespace PhotoUploaderApp.Application.Features.Queries.GetPhoto
{
    public class GetPhotoQueryResponse
    {
        public string Url { get; set; } = null!;
        public DateTime AddedDate { get; set; }
        public int DownloadCount { get; set; }
    }
}
