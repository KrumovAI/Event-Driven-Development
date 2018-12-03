namespace Genius.Services
{
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using System.Collections.Generic;

    public interface IAnnotationService : IService
    {
        Annotation GetById(int id);

        IEnumerable<AnnotationVM> GetBySong(int songId);

        void Add(AddAnnotationIM model);

        AnnotationVM Edit(EditAnnotationIM model);

        void Delete(int id);
    }
}
