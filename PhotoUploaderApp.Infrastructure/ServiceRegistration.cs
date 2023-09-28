using Microsoft.Extensions.DependencyInjection;
using PhotoUploaderApp.Application.Interfaces.Services;
using PhotoUploaderApp.Infrastructure.Services;

namespace PhotoUploaderApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.AddScoped<IPhotoService, PhotoService>();
        }
    }
}
