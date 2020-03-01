using JsonApi.Models;
using JsonApi.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JsonApi.Services
{
    public class JsonPhotoService : IJsonPhotoService
    {

        public async Task<List<Photo>> GetPhotos()
        {
            HttpClient client = new HttpClient();
            var baseUrl = "http://jsonplaceholder.typicode.com/photos";

            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await client.GetAsync(baseUrl);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var photoResponse = res.Content.ReadAsStringAsync().Result;

                var photos = JsonConvert.DeserializeObject<List<Photo>>(photoResponse);

                return photos;
            }

            return null;


        }

        public async Task<List<Photo>> GetPhotosByAlbumId(int id)
        {
            var photoList = new List<Photo>();
            HttpClient client = new HttpClient();
            var baseUrl = $"http://jsonplaceholder.typicode.com/photos";

            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await client.GetAsync(baseUrl);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var photoResponse = res.Content.ReadAsStringAsync().Result;

                var photos = JsonConvert.DeserializeObject<List<Photo>>(photoResponse);

                var result = photos.Where(x => x.AlbumId == id);

                foreach (var item in result)
                {
                    photoList.Add(item);
                }

                return photoList;
            }

            return null;
        }
    }
}
