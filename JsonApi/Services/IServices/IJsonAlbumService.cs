using JsonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonApi.Services.IServices
{
    public interface IJsonAlbumService
    {
        Task<List<Album>> GetAlbums();

        Task<List<Album>> GetAlbumsByUserId(int id);
    }
}
