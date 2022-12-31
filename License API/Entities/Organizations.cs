namespace License_API.Entities
{
    public record Organizations
    {
        public string OrgID { get; init; }

        public string Organization { get; init; }

        public string RUC { get; init; }

        public string ZipCode { get; init; }
    }
}
