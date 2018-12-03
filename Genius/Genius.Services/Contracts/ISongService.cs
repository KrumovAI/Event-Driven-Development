namespace Genius.Services
{
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISongService : IService
    {
        IEnumerable<ListSongVM> Search(string term);

        Song GetById(int id);

        SongVM Save(SaveSongIM model);

        void Delete(int id);
    }
}
