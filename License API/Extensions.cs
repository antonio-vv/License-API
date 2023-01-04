using License_API.DTOs;
using License_API.Entities;

namespace License_API
{
    public static class Extensions
    {
        public static LicenseKeyDTO AsDTO(this Licenses lic_key)
        {
            return new LicenseKeyDTO
            {
                Key = lic_key.Key,
                Creation = lic_key.Creation,
                Category = lic_key.Category,
                Expiration = lic_key.Expiration,
                CreateOps = lic_key.CreateOps,
                UpdateOps = lic_key.UpdateOps,
                AddOps = lic_key.AddOps,
                DeleteOps = lic_key.DeleteOps,
                Server = lic_key.Server,
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
                ZipCode = org.ZipCode,
            };
        }

        public static CategoriesDTO AsDTO(this Categories cat)
        {
            return new CategoriesDTO
            {
                Name = cat.Name,
                Creations = cat.Creations,
                Updates = cat.Updates,
                Additions = cat.Additions,
                Deletions = cat.Deletions,
            };
        }
    }
}
