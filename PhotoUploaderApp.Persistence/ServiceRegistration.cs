using Microsoft.Extensions.DependencyInjection;
using PhotoUploaderApp.Application.Interfaces.Repositories;
using PhotoUploaderApp.Persistence.Context;
using PhotoUploaderApp.Persistence.Repositories;

namespace PhotoUploaderApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PhotoUploaderDbContext>();
            serviceCollection.AddScoped<IPhotoRepository, PhotoRepository>();
        }
    }
}