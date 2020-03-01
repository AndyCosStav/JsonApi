using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApi.Models;

namespace JsonApi.Services.IServices
{
    public interface IJsonPhotoAlbumService
    {
        public Task<AlbumPhoto> GetAlbumPhoto();
        public Task<AlbumPhoto> GetAlbumPhotoByUserId(int id);
    }
}
