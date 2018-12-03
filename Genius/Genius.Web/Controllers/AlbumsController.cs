namespace Genius.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Genius.Models.Input;
    using Genius.Models.View;
    using Genius.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Route("albums")]
    public class AlbumsController : BaseController
    {
        private IAlbumService albumService;
        private IArtistService artistService;

        public AlbumsController(
            IMapper mapper,
            IAlbumService albumService,
            IArtistService artistService
        ) : base(mapper)
        {
            this.albumService = albumService;
            this.artistService = artistService;
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult Details(int id)
        {
            var album = this.albumService.GetById(id);
            var vm = this.mapper.Map<AlbumVM>(album);
            vm.Songs = album.Songs.OrderBy(s => s.TrackIndex).Select(s => this.mapper.Map<ListSongVM>(s));

            return View(vm);
        }

        [HttpGet]
        [Route("save")]
        [Authorize(Roles = "Admin")]
        public IActionResult Save(int? id, int? artistId)
        {
            var model = new SaveAlbumIM();

            if (id.HasValue)
            {
                model = this.mapper.Map<SaveAlbumIM>(this.albumService.GetById(id.Value));
            }
            else
            {
                if (artistId.HasValue)
                {
                    model.ArtistId = artistId.Value;
                }
            }

            return View(model);
        }

        [HttpPost]
        [Route("save")]
        [Authorize(Roles = "Admin")]
        public IActionResult Save(SaveAlbumIM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.CoverArtFile != null)
            {
                model.CoverArt = this.GetPhoto(model.CoverArtFile).Result;
            }

            var vm = this.albumService.Save(model);
            return RedirectToAction("Details", new { id = vm.Id });
        }

        [HttpGet]
        [Route("{id}/delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View(this.mapper.Map<AlbumVM>(this.albumService.GetById(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAlbum(int id)
        {
            this.albumService.Delete(id);
            return this.Redirect("Home");
        }
    }
}