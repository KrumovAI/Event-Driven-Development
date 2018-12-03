namespace Genius.Models.View
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SongVM
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public int TrackIndex { get; set; }

        public string Bio { get; set; }

        public string Lyrics { get; set; }
        
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public string CoverArt { get; set; }

        public IEnumerable<AnnotationVM> Annotations { get; set; }
    }
}
