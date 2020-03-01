using JsonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonApi.Services.IServices
{
    public interface IJsonPhotoService
    {
        Task<List<Photo>> GetPhotos();
        Task<List<Photo>> GetPhotosByAlbumId(int id);
    }
}
