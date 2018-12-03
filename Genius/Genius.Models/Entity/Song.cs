namespace Genius.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int TrackIndex { get; set; }

        public string Bio { get; set; }
        
        public string Lyrics { get; set; }
        
        [Required]
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public ICollection<Annotation> Annotations { get; set; } = new HashSet<Annotation>();
    }
}
