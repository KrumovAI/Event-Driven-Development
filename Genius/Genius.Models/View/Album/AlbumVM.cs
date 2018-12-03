namespace Genius.Models.View
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AlbumVM
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public int ReleaseYear { get; set; }
        
        public AlbumType Type { get; set; }

        public string CoverArt { get; set; }
        
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public IEnumerable<ListSongVM> Songs { get; set; } = new List<ListSongVM>();
    }
}
