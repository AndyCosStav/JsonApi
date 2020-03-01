using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApi.Models;
using JsonApi.Services.IServices;

namespace JsonApi.Services
{
    public class JsonPhotoAlbumService : IJsonPhotoAlbumService
    {
        private IJsonAlbumService albumService;

        private IJsonPhotoService photoService;


        public JsonPhotoAlbumService(IJsonPhotoService photoService, IJsonAlbumService albumService)
        {
            this.photoService = photoService;
            this.albumService = albumService;
        }

        public  async Task<AlbumPhoto> GetAlbumPhoto()
        {
            var photos = await this.photoService.GetPhotos();
            var albums = await this.albumService.GetAlbums();

            var newAlbum = new AlbumPhoto
            {
                Photos = photos,
                Albums = albums
            };

            return newAlbum;
        }

        public async Task<AlbumPhoto> GetAlbumPhotoByUserId(int id)
        {
            
            var album = await this.albumService.GetAlbumsByUserId(id);

            var photos = await this.photoService.GetPhotos();

            var albumIdList = new List<int>();

            foreach (var item in album)
            {
                albumIdList.Add(item.Id);
            }

            var photosInAlbums = photos.Where(x => albumIdList.Contains(x.AlbumId)).ToList();

            var newAlbum = new AlbumPhoto
            {
                Albums = album,
                Photos = photosInAlbums
            };


            return newAlbum;
        }

    }
}
 