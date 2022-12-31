namespace License_API.Entities
{
    public record Categories
    {
        public string Name { get; init; }

        public int Creations { get; init; }

        public int Updates { get; init; }

        public int Additions { get; init; }

        public int Deletions { get; init; }
    }
}
