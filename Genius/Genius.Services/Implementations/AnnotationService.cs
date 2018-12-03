namespace Genius.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using Genius.Data;
    using Genius.Models;
    using System.Linq;
    using Genius.Models.View;
    using Genius.Models.Input;
    using Microsoft.EntityFrameworkCore;
    using Genius.Common.Exceptions;

    public class AnnotationService : Service, IAnnotationService
    {
        private IRepository<Annotation> annotations;

        public AnnotationService(
            IMapper mapper,
            IRepository<Annotation> annotations
        ) : base(mapper)
        {
            this.annotations = annotations;
        }

        public Annotation GetById(int id)
        {
            var annotation = this.annotations.GetById(id);

            if (annotation == null)
            {
                throw new EntityNotFoundException();
            }

            return annotation;
        }

        public IEnumerable<AnnotationVM> GetBySong(int songId)
        {
            var annotations = this.annotations
                .GetAll(entity => entity.Include(a => a.Author))
                .Where(a => a.SongId == songId)
                .Select(a => this.mapper.Map<AnnotationVM>(a))
                .ToList();

            return annotations;
        }

        public void Add(AddAnnotationIM model)
        {
            Annotation annotation = this.mapper.Map<Annotation>(model);
            this.annotations.Add(annotation);
            this.annotations.Save();
        }
        
        public AnnotationVM Edit(EditAnnotationIM model)
        {
            Annotation annotation = this.annotations
                .GetAll(entity => entity.Include(a => a.Author))
                .FirstOrDefault(a => a.Id == model.Id);
                        
            if (annotation == null)
            {
                throw new EntityNotFoundException();
            }

            annotation.Content = model.Content;
            this.annotations.Save();

            return this.mapper.Map<AnnotationVM>(annotation);
        }

        public void Delete(int id)
        {
            Annotation annotation = this.annotations.GetById(id);

            if (annotation == null)
            {
                throw new EntityNotFoundException();
            }

            this.annotations.Delete(annotation);
            this.annotations.Save();
        }
    }
}
