namespace Genius.Services
{
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IArtistService : IService
    {
        IEnumerable<ListArtistVM> Search(string term);
        
        Artist GetById(int id);

        ArtistVM Save(SaveArtistIM model);

        void Delete(int id);
    }
}
