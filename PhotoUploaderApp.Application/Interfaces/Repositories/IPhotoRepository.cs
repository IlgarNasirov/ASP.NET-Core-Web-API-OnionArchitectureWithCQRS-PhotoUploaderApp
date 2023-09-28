using PhotoUploaderApp.Domain.Entities;

namespace PhotoUploaderApp.Application.Interfaces.Repositories
{
    public interface IPhotoRepository
    {
        public Task<Photo> AddPhoto(Photo photo);

        public Task<Photo> DownloadPhoto(Photo photo);

        public Task<List<Photo>> GetThePhotosOfToday();

        public Task<int> GetAllPhotosCount();

        public Task<Photo?> GetPhoto(string shortId);

        public Task<Photo> GetRandomPhoto();
    }
}
