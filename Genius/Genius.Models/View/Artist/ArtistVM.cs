namespace Genius.Models.View
{
    using System.Collections.Generic;

    public class ArtistVM
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string About { get; set; }

        public string Photo { get; set; }

        public IEnumerable<ListAlbumVM> Albums { get; set; }
    }
}
