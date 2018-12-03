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

    public class SongService : Service, ISongService
    {
        private IRepository<Song> songs;

        public SongService(
            IRepository<Song> songs,
            IMapper mapper
        ) : base(mapper)
        {
            this.songs = songs;
        }

        public IEnumerable<ListSongVM> Search(string term)
        {
            var songs = this.songs
                .GetAll(entity => entity
                    .Include(s => s.Album))
                .Where(a => a.Title.Contains(term))
                .Select(a => this.mapper.Map<ListSongVM>(a))
                .ToList();

            return songs;
        }

        public Song GetById(int id)
        {
            var song = this.songs
                .GetAll(entity => entity
                    .Include(a => a.Album).ThenInclude(a => a.Artist)
                    .Include(a => a.Annotations).ThenInclude(a => a.Author))
                .FirstOrDefault(a => a.Id == id);

            if (song == null)
            {
                throw new EntityNotFoundException();
            }

            return song;
        }

        public SongVM Save(SaveSongIM model)
        {
            Song song = new Song();

            if (model.Id.HasValue)
            {
                song = this.songs.GetById(model.Id.Value);

                if (song == null)
                {
                    throw new EntityNotFoundException();
                }
            }

            song.Title = model.Title;
            song.TrackIndex = model.TrackIndex;
            song.Lyrics = model.Lyrics.Trim();
            song.Bio = model.Bio;
            song.AlbumId = model.AlbumId;

            string newLine = "\r\n";

            if (song.Lyrics.StartsWith(newLine))
            {
                song.Lyrics = song.Lyrics.Remove(0, newLine.Length);
            }

            if (!model.Id.HasValue)
            {
                this.songs.Add(song);
            }

            this.songs.Save();
            return this.mapper.Map<SongVM>(song);
        }

        public void Delete(int id)
        {
            var song = this.songs.GetById(id);

            if (song == null)
            {
                throw new EntityNotFoundException();
            }

            this.songs.Delete(song);
            this.songs.Save();
        }
    }
}
