namespace Genius.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Genius.Models.Input;
    using Genius.Services;
    using Genius.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Authorize]
    [Route("annotations")]
    public class AnnotationsController : BaseController
    {
        private IAnnotationService annotationService;

        public AnnotationsController(
            IMapper mapper,
            IAnnotationService annotationService
        ) : base(mapper)
        {
            this.annotationService = annotationService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AddAnnotationIM model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Songs", new { id = model.SongId });
            }

            model.AuthorId = this.User.GetUserId();
            this.annotationService.Add(model);
            return this.RedirectToAction("Details", "Songs", new { id = model.SongId });
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(EditAnnotationIM model)
        {
            var annotation = this.annotationService.GetById(model.Id);

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Songs", new { id = annotation.SongId });
            }

            if (annotation.AuthorId == this.User.GetUserId())
            {
                var vm = this.annotationService.Edit(model);
            }

            return this.RedirectToAction("Details", "Songs", new { id = annotation.SongId });
        }
        
        [HttpPost]
        [Route("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var annotation = this.annotationService.GetById(id);

            if (annotation.AuthorId == this.User.GetUserId())
            {
                this.annotationService.Delete(id);
            }

            return this.RedirectToAction("Details", "Songs", new { id = annotation.SongId });
        }
    }
}
