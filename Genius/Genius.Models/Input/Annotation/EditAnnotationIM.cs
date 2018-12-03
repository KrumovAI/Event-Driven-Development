namespace Genius.Models.Input
{
    using System.ComponentModel.DataAnnotations;

    public class EditAnnotationIM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
