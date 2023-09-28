namespace PhotoUploaderApp.Application.Features.Queries.GetThePhotosOfToday
{
    public class GetThePhotosOfTodayQueryResponse
    {
        public string Url { get; set; } = null!;
        public int DownloadCount { get; set; }
    }
}
