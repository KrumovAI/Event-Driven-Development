namespace Genius.Services
{
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAlbumService : IService
    {
        IEnumerable<ListAlbumVM> Search(string term);

        Album GetById(int id);

        AlbumVM Save(SaveAlbumIM model);

        void Delete(int id);
    }
}
