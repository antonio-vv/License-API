namespace License_API.DTOs
{
    public class LicenseKeyDTO
    {
        public Guid Id { get; init; }

        public DateTimeOffset Creation { get; init; }

        public string Category { get; init; }

        public DateTimeOffset Expiration { get; init; }
    }
}
