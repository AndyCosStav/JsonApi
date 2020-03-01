using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApi.Services;
using JsonApi.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void GetPhotoAlbums(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddScoped<IJsonPhotoService, JsonPhotoService>();
            serviceCollection.AddScoped<IJsonAlbumService, JsonAlbumService>();
            serviceCollection.AddScoped<IJsonPhotoAlbumService, JsonPhotoAlbumService>();
        }
    }
}
