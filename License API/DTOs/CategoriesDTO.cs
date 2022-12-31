using System.ComponentModel.DataAnnotations;

namespace License_API.DTOs
{
    public record CategoriesDTO
    {
        public string Name { get; init; }

        public int Creations { get; init; }

        public int Updates { get; init; }

        public int Additions { get; init; }

        public int Deletions { get; init; }
    }

    public record NewCatDTO
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public int Creations { get; init; }

        [Required]
        public int Updates { get; init; }

        [Required]
        public int Additions { get; init; }

        [Required]
        public int Deletions { get; init; }
    }

    public record UpdateCatDTO
    {
        [Required]
        public int Creations { get; init; }

        [Required]
        public int Updates { get; init; }

        [Required]
        public int Additions { get; init; }

        [Required]
        public int Deletions { get; init; }
    }
}
