using MediatR;
using PhotoUploaderApp.Application.Interfaces.Repositories;
using PhotoUploaderApp.Application.Interfaces.Services;
using PhotoUploaderApp.Domain.Entities;
using shortid.Configuration;
using shortid;

namespace PhotoUploaderApp.Application.Features.Commands.AddPhoto
{
    public class AddPhotoCommandHandler:IRequestHandler<AddPhotoCommandRequest, AddPhotoCommandResponse?>
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoService _uploadPhotoService;
        public AddPhotoCommandHandler(IPhotoRepository photoRepository, IPhotoService uploadPhotoService)
        {
            _photoRepository = photoRepository;
            _uploadPhotoService = uploadPhotoService;
        }
        public async Task<AddPhotoCommandResponse?>Handle(AddPhotoCommandRequest addPhotoCommandRequest, CancellationToken cancellationToken)
        {
            var options = new GenerationOptions(length: 15, useNumbers: true, useSpecialCharacters: false);
            var flag = false;
            var shortId = "";
            while (flag == false)
            {
                shortId = ShortId.Generate(options);
                var photo = await _photoRepository.GetPhoto(shortId);
                if (photo == null)
                {
                    flag = true;
                }
            }
            var check = _uploadPhotoService.CheckTheExtensionOfFile(addPhotoCommandRequest.Photo);
            if (check == false)
                return null;
            var result = await _uploadPhotoService.UploadPhoto(addPhotoCommandRequest.Photo, shortId);
            var p = await _photoRepository.AddPhoto(new Photo { Url = result });
            return new AddPhotoCommandResponse { URL = p.Url.Split('.')[0] };
        }
    }
}
