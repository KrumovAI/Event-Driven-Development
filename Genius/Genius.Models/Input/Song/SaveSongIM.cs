namespace Genius.Models.Input
{
    using System.ComponentModel.DataAnnotations;

    public class SaveSongIM
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int TrackIndex { get; set; }

        public string Bio { get; set; }

        public string Lyrics { get; set; }

        [Required]
        public int AlbumId { get; set; }
    }
}
