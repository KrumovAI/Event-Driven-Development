namespace Genius.Models.View
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnnotationVM
    {
        public int Id { get; set; }
        
        public int SongId { get; set; }
        
        public string Text { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public ICollection<AnnotationVoteVM> Votes { get; set; } = new HashSet<AnnotationVoteVM>();
    }
}
