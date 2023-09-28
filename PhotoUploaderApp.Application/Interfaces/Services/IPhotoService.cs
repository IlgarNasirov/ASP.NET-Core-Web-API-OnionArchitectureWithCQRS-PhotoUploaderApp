using Microsoft.AspNetCore.Http;
namespace PhotoUploaderApp.Application.Interfaces.Services
{
    public interface IPhotoService
    {
        public Task<string> UploadPhoto(IFormFile photo, string name);
        public bool CheckTheExtensionOfFile(IFormFile file);
    }
}
