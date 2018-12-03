namespace Genius.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public AlbumType Type { get; set; }

        public byte[] CoverArt { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
