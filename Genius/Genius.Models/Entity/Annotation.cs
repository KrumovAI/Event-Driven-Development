namespace Genius.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Annotation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SongId { get; set; }

        public Song Song { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }
        
        public ICollection<UserAnnotationVote> Votes { get; set; } = new HashSet<UserAnnotationVote>();
    }
}
