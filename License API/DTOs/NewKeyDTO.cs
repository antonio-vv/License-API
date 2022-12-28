using System.ComponentModel.DataAnnotations;

namespace License_API.DTOs
{
    public record NewKeyDTO
    {
        [Required]
        public DateTimeOffset Creation { get; init; }

        [Required]
        public string Category { get; init; }
    }
}
