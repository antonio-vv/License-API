using License_API.DTOs;
using License_API.Entities;

namespace License_API
{
    public static class Extensions
    {
        public static LicenseKeyDTO AsDTO(this LicenseKey lic_key)
        {
            return new LicenseKeyDTO
            {
                Id = lic_key.Id,
                Creation = lic_key.Creation,
                Category = lic_key.Category,
                Expiration = lic_key.Expiration,
            };
        }
    }
}
