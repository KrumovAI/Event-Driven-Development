namespace Genius.Models.Input
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SaveAlbumIM
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public AlbumType Type { get; set; }

        [Required]
        public int ArtistId { get; set; }
        
        public IFormFile CoverArtFile { get; set; }

        public byte[] CoverArt { get; set; }
    }
}
