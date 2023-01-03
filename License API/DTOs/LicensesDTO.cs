using System.ComponentModel.DataAnnotations;

namespace License_API.DTOs
{
    public record LicenseKeyDTO
    {
        public Guid Key { get; init; }

        public DateTimeOffset Creation { get; init; }

        public string Category { get; init; }

        public DateTimeOffset Expiration { get; init; }

        public int CreateOps { get; init; }

        public int UpdateOps { get; init; }

        public int AddOps { get; init; }

        public int DeleteOps { get; init; }

        public string? Server { get; init; }

        public string Org_ID { get; init; }
    }

    public record NewKeyDTO
    {
        [Required]
        public string Category { get; init; }

        public string? Server { get; init; }

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

    public record BindKeyDTO
    {
        [Required]
        public string Server { get; init; }
    }
}