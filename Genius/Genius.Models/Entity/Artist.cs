namespace Genius.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string About { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}
