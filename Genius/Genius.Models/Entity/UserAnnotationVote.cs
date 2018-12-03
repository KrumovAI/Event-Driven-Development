namespace Genius.Models
{
    public class UserAnnotationVote
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int AnnotationId { get; set; }

        public Annotation Annotation { get; set; }

        public VoteType Type { get; set; }
    }
}
