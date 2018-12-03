namespace Genius.Models.Input
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class AddAnnotationIM
    {
        [Required]
        public int SongId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }
    }
}
