namespace License_API.Entities
{
    public record Licenses
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
}
