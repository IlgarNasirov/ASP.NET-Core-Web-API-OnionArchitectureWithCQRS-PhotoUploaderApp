using Microsoft.AspNetCore.Http;
using PhotoUploaderApp.Application.Interfaces.Services;

namespace PhotoUploaderApp.Infrastructure.Services
{
    public class PhotoService: IPhotoService
    {
        public async Task<string>UploadPhoto(IFormFile photo, string name)
        {
            string fileName = photo.FileName;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TempImages", fileName);
            string file = name + Path.GetExtension(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            using (Image image = await Image.LoadAsync(filePath))
            {
            image.Mutate(x => x.Resize(500, 500));
            await image.SaveAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", file));
            }

            File.Delete(filePath);
            return file;
        }

        public bool CheckTheExtensionOfFile(IFormFile file)
        {
            string fileExtension= Path.GetExtension(file.FileName);
            if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                return true;
            return false;
        }
    }
}