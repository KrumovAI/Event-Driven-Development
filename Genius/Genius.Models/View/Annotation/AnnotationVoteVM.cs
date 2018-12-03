namespace Genius.Models.View
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnnotationVoteVM
    {
        public string UserId { get; set; }
        
        public int AnnotationId { get; set; }
        
        public VoteType Type { get; set; }
    }
}
