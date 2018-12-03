namespace Genius.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Genius.Models.View;
    using Genius.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("search")]
    public class SearchController : BaseController
    {
        private ISongService songService;
        private IAlbumService albumService;
        private IArtistService artistService;

        public SearchController(
            IMapper mapper,
            ISongService songService,
            IAlbumService albumService,
            IArtistService artistService
        ) : base(mapper)
        {
            this.songService = songService;
            this.albumService = albumService;
            this.artistService = artistService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Search(string term = "")
        {
            term = term.ToLower();
            var vm = new SearchVM();

            vm.Songs = this.songService.Search(term);
            vm.Albums = this.albumService.Search(term);
            vm.Artists = this.artistService.Search(term);

            return View(vm);
        }
    }
}