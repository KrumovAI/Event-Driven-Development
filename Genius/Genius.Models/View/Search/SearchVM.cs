namespace Genius.Models.View
{
    using System.Collections.Generic;

    public class SearchVM
    {
        public IEnumerable<ListSongVM> Songs { get; set; } = new List<ListSongVM>();

        public IEnumerable<ListAlbumVM> Albums { get; set; } = new List<ListAlbumVM>();

        public IEnumerable<ListArtistVM> Artists { get; set; } = new List<ListArtistVM>();
    }
}
