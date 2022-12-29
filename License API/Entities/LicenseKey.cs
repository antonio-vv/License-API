namespace License_API.Entities
{
    public record LicenseKey
    {
        public Guid Id { get; init; }

        public DateTimeOffset Creation { get; init; }

        public string Category { get; init; }

        public DateTimeOffset Expiration { get; init; }

        public string Org_ID { get; init; }
    }
}
