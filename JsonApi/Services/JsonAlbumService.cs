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
    public class JsonAlbumService : IJsonAlbumService
    {
        public async Task<List <Album>> GetAlbums()
        {
            HttpClient client = new HttpClient();
            var baseUrl = "http://jsonplaceholder.typicode.com/albums";

            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await client.GetAsync(baseUrl);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var albumResponse = res.Content.ReadAsStringAsync().Result;

                var albums = JsonConvert.DeserializeObject<List<Album>>(albumResponse);

                return albums;
            }

            return null;


        }

        public async Task<List<Album>>GetAlbumsByUserId(int id)
        {
            var albumsList = new List<Album>();

            HttpClient client = new HttpClient();
            var baseUrl = $"http://jsonplaceholder.typicode.com/albums/";

            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await client.GetAsync(baseUrl);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var albumResponse = res.Content.ReadAsStringAsync().Result;

                var albums = JsonConvert.DeserializeObject<List<Album>>(albumResponse);

                var result = albums.Where(x => x.UserId == id);

                foreach (var item in result)
                {
                    albumsList.Add(item);
                }

                return albumsList;
            }

            return null;
        }
    }
}
