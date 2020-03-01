﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JsonApi.Models;
using JsonApi.Services;
using JsonApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JSONController : ControllerBase
    {
        private IJsonPhotoAlbumService photoAlbum;

        public JSONController(IJsonPhotoAlbumService photoAlbum)
        {
            this.photoAlbum = photoAlbum;
        }

        // GET: api/JSON
        [HttpGet]
        public async Task<AlbumPhoto> Get()
        {
            var result = await this.photoAlbum.GetAlbumPhoto();

            return result;
        }

        // GET: api/JSON/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<AlbumPhoto> GetByUserId(int id)
        {
            var result = await this.photoAlbum.GetAlbumPhotoByUserId(id);

            return result;
        }

      
    }
}
