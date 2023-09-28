using Microsoft.EntityFrameworkCore;
using PhotoUploaderApp.Application.Interfaces.Repositories;
using PhotoUploaderApp.Domain.Entities;
using PhotoUploaderApp.Persistence.Context;

namespace PhotoUploaderApp.Persistence.Repositories
{
    public class PhotoRepository:IPhotoRepository
    {
        private readonly PhotoUploaderDbContext _context;
        public PhotoRepository(PhotoUploaderDbContext context)
        {
                _context= context;
        }

        public async Task<Photo> AddPhoto(Photo photo)
        {
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<Photo> DownloadPhoto(Photo photo)
        {
            photo!.DownloadCount++;
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<List<Photo>> GetThePhotosOfToday()
        {
            return await _context.Photos.Where(p=>p.Status == true && p.AddedDate.Day==DateTime.Now.Day).ToListAsync();
        }

        public async Task<int> GetAllPhotosCount()
        {
            return await _context.Photos.Where(p => p.Status == true).CountAsync();
        }

        public async Task<Photo?> GetPhoto(string shortId)
        {
            return await _context.Photos.Where(p => (p.Url==shortId+".jpg"|| p.Url == shortId + ".jpeg"|| p.Url == shortId + ".png") && p.Status == true).FirstOrDefaultAsync();
        }

        public async Task<Photo> GetRandomPhoto()
        {
            var photos = await _context.Photos.Where(p => p.Status == true).ToListAsync();
            var random = new Random().Next(photos.Count());
            return photos[random];
        }

    }
}