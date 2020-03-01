using JsonApi.Controllers;
using JsonApi.Models;
using JsonApi.Services.IServices;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JsonTests
{
    public class ResponseTests
    {
        [Fact]
        public async Task GetPhotoAlbum()
        {
            var findAlbumResponse = new Album
            {
                UserId = 2, 
                Id = 20, 
                Title = "voluptas rerum iure ut enim"

            };

            var findPhotoResponse = new Photo
            {
                Id = 1000,
                AlbumId = 20,
                Title = "est consequatur deleniti quos minus",
                Url = "https://via.placeholder.com/600/fab5da",
                ThumbnailUrl = "https://via.placeholder.com/150/fab5da"
            };


            var PhotoAlbumResponse = new AlbumPhoto
            {
                Photos = new List<Photo> { findPhotoResponse },
                Albums = new List<Album> { findAlbumResponse }
            };

            var photoAlbumRepo = new Mock<IJsonPhotoAlbumService>();

            photoAlbumRepo.Setup(x => x.GetAlbumPhotoByUserId(2)).ReturnsAsync(PhotoAlbumResponse);

            var classUnderTest = new JSONController(photoAlbumRepo.Object);

            var result = await classUnderTest.GetByUserId(2);

            Assert.True(result.Equals(PhotoAlbumResponse));

        }
    }
}
