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
                Org_ID = lic_key.Org_ID,
            };
        }

        public static OrganizationsDTO AsDTO(this Organizations org)
        {
            return new OrganizationsDTO
            {
                OrgID = org.OrgID,
                Organization = org.Organization,
                RUC = org.RUC,
                ZipCode = org.RUC,
            };
        }

        public static ServersDTO AsDTO(this Server srvr)
        {
            return new ServersDTO
            {
                ServID = srvr.ServID,
                CreateOps = srvr.CreateOps,
                UpdateOps = srvr.UpdateOps,
                AddOps = srvr.AddOps,
                DeleteOps = srvr.DeleteOps,
                Lic_Key = srvr.Lic_Key,
            };
        }
    }
}
