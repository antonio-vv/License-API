using System.ComponentModel.DataAnnotations;

namespace License_API.DTOs
{
    public class LicenseKeyDTO
    {
        public Guid Id { get; init; }

        public DateTimeOffset Creation { get; init; }

        public string Category { get; init; }

        public DateTimeOffset Expiration { get; init; }

        public string Org_ID { get; init; }
    }

    public record NewKeyDTO
    {
        [Required]
        public string Category { get; init; }

        [Required]
        public string Org_ID { get; init; }
    }

    public record UpgradeKeyDTO
    {
        [Required]
        public string Category { get; init; }
    }

    public record RenewKeyDTO
    {
        [Required]
        public DateTimeOffset Expiration { get; init; }
    }
}