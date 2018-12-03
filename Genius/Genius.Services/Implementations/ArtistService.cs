namespace Genius.Services
{
    using AutoMapper;
    using Genius.Common.Exceptions;
    using Genius.Data;
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class ArtistService : Service, IArtistService
    {
        private IRepository<Artist> artists;

        public ArtistService(
            IRepository<Artist> artists,
            IMapper mapper
        ) : base(mapper)
        {
            this.artists = artists;
        }

        public IEnumerable<ListArtistVM> Search(string term)
        {
            var artists = this.artists
                .GetAll()
                .Where(a => a.Name.ToLower().Contains(term.ToLower()))
                .Select(a => this.mapper.Map<ListArtistVM>(a))
                .ToList();

            return artists;
        }

        public Artist GetById(int id)
        {
            var artist = this.artists
                .GetAll(entity => entity
                    .Include(a => a.Albums))
                .FirstOrDefault(a => a.Id == id);
            
            if (artist == null)
            {
                throw new EntityNotFoundException();
            }

            return artist;
        }

        public ArtistVM Save(SaveArtistIM model)
        {
            Artist artist = new Artist();

            if (model.Id.HasValue)
            {
                artist = this.artists.GetById(model.Id.Value);

                if (artist == null)
                {
                    throw new EntityNotFoundException();
                }
            }

            artist.Name = model.Name;
            artist.About = model.About;

            if (model.Photo != null)
            {
                artist.Photo = model.Photo;
            }

            if (!model.Id.HasValue)
            {
                this.artists.Add(artist);
            }

            this.artists.Save();
            return this.mapper.Map<ArtistVM>(artist);
        }

        public void Delete(int id)
        {
            var artist = this.artists.GetById(id);

            if (artist == null)
            {
                throw new EntityNotFoundException();
            }

            this.artists.Delete(artist);
            this.artists.Save();
        }
    }
}
