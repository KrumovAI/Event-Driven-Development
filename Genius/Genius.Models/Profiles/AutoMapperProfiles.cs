namespace Genius.Models.Profiles
{
    using AutoMapper;
    using Genius.Models;
    using Genius.Models.Input;
    using Genius.Models.View;
    using System;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() : base()
        {
            // Artists
            this.CreateMap<Artist, SaveArtistIM>();
            this.CreateMap<Artist, ListArtistVM>()
                .ForMember(a => a.Photo, cfg => cfg.MapFrom(a => Convert.ToBase64String(a.Photo)));

            this.CreateMap<Artist, ArtistVM>()
                .ForMember(a => a.Photo, cfg => cfg.MapFrom(a => Convert.ToBase64String(a.Photo)));

            // Albums
            this.CreateMap<Album, SaveAlbumIM>();

            this.CreateMap<Album, AlbumVM>()
                .ForMember(a => a.ArtistName, cfg => cfg.MapFrom(a => a.Artist.Name))
                .ForMember(a => a.CoverArt, cfg => cfg.MapFrom(a => Convert.ToBase64String(a.CoverArt)));

            this.CreateMap<Album, ListAlbumVM>()
                .ForMember(a => a.CoverArt, cfg => cfg.MapFrom(a => Convert.ToBase64String(a.CoverArt)));

            // Songs
            this.CreateMap<Song, ListSongVM>()
                .ForMember(s => s.CoverArt, cfg => cfg.MapFrom(a => Convert.ToBase64String(a.Album.CoverArt)));

            this.CreateMap<Song, SongVM>()
                .ForMember(s => s.AlbumName, cfg => cfg.MapFrom(a => a.Album.Title))
                .ForMember(s => s.ArtistId, cfg => cfg.MapFrom(a => a.Album.ArtistId))
                .ForMember(s => s.ArtistName, cfg => cfg.MapFrom(a => a.Album.Artist.Name))
                .ForMember(s => s.CoverArt, cfg => cfg.MapFrom(a => Convert.ToBase64String(a.Album.CoverArt)));

            // Annotations
            this.CreateMap<Annotation, AnnotationVM>()
                .ForMember(a => a.AuthorName, cfg => cfg.MapFrom(a => a.Author.UserName));
            this.CreateMap<AddAnnotationIM, Annotation>();
        }
    }
}
