﻿namespace License_API.Entities
{
    public class Organizations
    {
        public Guid OrgID { get; init; }

        public string Organization { get; init; }

        public string RUC { get; init; }

        public string ZipCode { get; init; }
    }
}
