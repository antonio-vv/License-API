using System.ComponentModel.DataAnnotations;

namespace License_API.DTOs
{
    public class OrganizationsDTO
    {
        public string OrgID { get; init; }

        public string Organization { get; init; }

        public string RUC { get; init; }

        public string ZipCode { get; init; }
    }

    public record NewOrgDTO
    {
        [Required]
        public string Organization { get; init; }

        [Required]
        public string RUC { get; init; }

        [Required]
        public string ZipCode { get; init; }
    }
}
