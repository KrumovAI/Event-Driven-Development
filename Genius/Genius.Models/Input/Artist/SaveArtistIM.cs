namespace Genius.Models.Input
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class SaveArtistIM
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string About { get; set; }

        public byte[] Photo { get; set; }

        public IFormFile PhotoFile { get; set; }
    }
}
