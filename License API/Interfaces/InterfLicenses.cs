using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfLicenses
    {
        Licenses GetKey(Guid id);

        IEnumerable<Licenses> GetOrgLics(string org_id);

        void CreateKey(Licenses licenseKey);

        void UpgradeKey(Licenses licenseKey);

        void RenewKey(Licenses licenseKey);

        void CreateCount(Licenses licenseKey);
        
        void UpdateCount(Licenses licenseKey);

        void AddCount(Licenses licenseKey);

        void DeleteCount(Licenses licenseKey);

        void BindServer(Licenses licenseKey);

        void UnbindServer(Licenses licenseKey);
    }
}