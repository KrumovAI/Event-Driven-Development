namespace Genius.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public ICollection<Annotation> Annotations { get; set; } = new HashSet<Annotation>();

        public ICollection<UserAnnotationVote> AnnotationVotes { get; set; } = new HashSet<UserAnnotationVote>();
    }
}
