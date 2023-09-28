namespace PhotoUploaderApp.Domain.Entities
{
    public partial class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; } = null!;

        public DateTime AddedDate { get; set; }

        public int DownloadCount { get; set; }

        public bool? Status { get; set; }
    }
}