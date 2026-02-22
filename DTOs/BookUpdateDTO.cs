using System.ComponentModel.DataAnnotations;

namespace echal2025library.DTOs
{
    public class BookUpdateDTO
    {
        [Required()]
        public string Title { get; set; } = string.Empty;

        [Required()]
        public string Author { get; set; } = string.Empty;

        [Required()]
        [Range(1900, 2026)]
        public int PublicationYear { get; set; }

        [Required()]
        public string ISBN { get; set; } = string.Empty;

        [Required()]
        [Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }
    }
}
