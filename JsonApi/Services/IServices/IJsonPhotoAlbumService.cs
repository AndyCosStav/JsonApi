using JsonApi.Models;
using System.Threading.Tasks;

namespace JsonApi.Services.IServices
{
    public interface IJsonPhotoAlbumService
    {
        public Task<AlbumPhoto> GetAlbumPhoto();
        public Task<AlbumPhoto> GetAlbumPhotoByUserId(int id);
    }
}
