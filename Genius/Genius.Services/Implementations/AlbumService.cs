namespace Genius.Services
{
    using AutoMapper;
    using Genius.Data;
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Collections.Generic;
    using Genius.Common.Exceptions;

    public class AlbumService : Service, IAlbumService
    {
        private IRepository<Album> albums;

        public AlbumService(
            IRepository<Album> albums,
            IMapper mapper
        ) : base(mapper)
        {
            this.albums = albums;
        }

        public IEnumerable<ListAlbumVM> Search(string term)
        {
            var albums = this.albums
                .GetAll()
                .Where(a => a.Title.ToLower().Contains(term.ToLower()))
                .Select(a => this.mapper.Map<ListAlbumVM>(a))
                .ToList();

            return albums;
        }

        public Album GetById(int id)
        {
            var album = this.albums
                .GetAll(entity => entity
                    .Include(a => a.Artist)
                    .Include(a => a.Songs))
                .FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                throw new EntityNotFoundException();
            }

            return album;
        }
        
        public AlbumVM Save(SaveAlbumIM model)
        {
            Album album = new Album();

            if (model.Id.HasValue)
            {
                album = this.albums.GetById(model.Id.Value);
                
                if (album == null)
                {
                    throw new EntityNotFoundException();
                }
            }

            album.Title = model.Title;
            album.ReleaseYear = model.ReleaseYear;
            album.Type = model.Type;
            album.ArtistId = model.ArtistId;

            if (model.CoverArt != null)
            {
                album.CoverArt = model.CoverArt;
            }

            if (!model.Id.HasValue)
            {
                this.albums.Add(album);
            }

            this.albums.Save();
            return this.mapper.Map<AlbumVM>(album);
        }

        public void Delete(int id)
        {
            var album = this.albums.GetById(id);
            
            if (album == null)
            {
                throw new EntityNotFoundException();
            }

            this.albums.Delete(album);
            this.albums.Save();
        }
    }
}
