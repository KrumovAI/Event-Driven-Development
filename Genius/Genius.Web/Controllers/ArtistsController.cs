using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Genius.Models.Input;
using Genius.Models.View;
using Genius.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genius.Web.Controllers
{
    [Route("artists")]
    public class ArtistsController : BaseController
    {
        private IArtistService artistService;

        public ArtistsController(
            IArtistService artistService,
            IMapper mapper
        ) : base(mapper)
        {
            this.artistService = artistService;
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult Details(int id)
        {
            var artist = this.artistService.GetById(id);
            var vm = this.mapper.Map<ArtistVM>(artist);
            vm.Albums = artist.Albums.OrderByDescending(a => a.ReleaseYear).Select(a => this.mapper.Map<ListAlbumVM>(a));

            return View(vm);
        }

        [HttpGet]
        [Route("save")]
        [Authorize(Roles = "Admin")]
        public IActionResult Save(int? id)
        {
            var model = new SaveArtistIM();
            
            if (id.HasValue)
            {
                model = this.mapper.Map<SaveArtistIM>(this.artistService.GetById(id.Value));
            }

            return View(model);
        }

        [HttpPost]
        [Route("save")]
        [Authorize(Roles = "Admin")]
        public IActionResult Save(SaveArtistIM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.PhotoFile != null)
            {
                model.Photo = this.GetPhoto(model.PhotoFile).Result;
            }

            var vm = this.artistService.Save(model);
            return RedirectToAction("Details", new { id = vm.Id });
        }

        [HttpGet]
        [Route("{id}/delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View(this.mapper.Map<ArtistVM>(this.artistService.GetById(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteArtist(int id)
        {
            this.artistService.Delete(id);
            return this.Redirect("Home");
        }
    }
}