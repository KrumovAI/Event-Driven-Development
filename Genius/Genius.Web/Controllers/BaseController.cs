using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genius.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected async Task<byte[]> GetPhoto(IFormFile file)
        {
            byte[] photo;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                photo = memoryStream.ToArray();
            }

            return photo;
        }
    }
}