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

    [Route("songs")]
    public class SongsController : BaseController
    {
        ISongService songService;

        public SongsController(
            IMapper mapper,
            ISongService songService
        ) : base(mapper)
        {
            this.songService = songService;
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult Details(int id)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            var song = this.songService.GetById(id);
            var vm = this.mapper.Map<SongVM>(song);
            vm.Annotations = song.Annotations.Select(a => this.mapper.Map<AnnotationVM>(a));

            return View(vm);
        }

        [HttpGet]
        [Route("save")]
        [Authorize(Roles = "Admin")]
        public IActionResult Save(int? id, int? albumId)
        {
            var model = new SaveSongIM();

            if (id.HasValue)
            {
                model = this.mapper.Map<SaveSongIM>(this.songService.GetById(id.Value));
            }
            else
            {
                if (albumId.HasValue)
                {
                    model.AlbumId = albumId.Value;
                }
            }

            return View(model);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save(SaveSongIM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var vm = this.songService.Save(model);
            return RedirectToAction("Details", new { id = vm.Id });
        }

        [HttpGet]
        [Route("{id}/delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View(this.mapper.Map<ListSongVM>(this.songService.GetById(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSong(int id)
        {
            this.songService.Delete(id);
            return this.Redirect("Home");
        }
    }
}