using System.ComponentModel.DataAnnotations;

namespace License_API.DTOs
{
    public class ServersDTO
    {
        public string ServID { get; init; }

        public int CreateOps { get; init; }

        public int UpdateOps { get; init; }

        public int AddOps { get; init; }

        public int DeleteOps { get; init; }

        public Guid? Lic_Key { get; init; }
    }

    public record NewSrvrDTO
    {
        [Required]
        public string ServID { get; init; }

        public Guid Lic_Key { get; init; }
    }

    public record LicenseSrvrDTO
    {
        [Required]
        public Guid Lic_Key { get; init; }
    }
}
