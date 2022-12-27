namespace License_API.Entities
{
    public record LicenseKey
    {
        public Guid Id { get; init; }

        public string Organization { get; init; }

        public string Server { get; init; }

        public DateTimeOffset Creation { get; init; }
    }
}
