using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfLicenses
    {
        Licenses GetKey(Guid id);

        IEnumerable<Licenses> GetOrgLics(string org_id);

        bool CreateKey(Licenses licenseKey);

        bool UpgradeKey(Licenses licenseKey);

        bool RenewKey(Licenses licenseKey);

        bool CreateCount(Licenses licenseKey);
        
        bool UpdateCount(Licenses licenseKey);

        bool AddCount(Licenses licenseKey);

        bool DeleteCount(Licenses licenseKey);

        bool BindServer(Licenses licenseKey);

        bool UnbindServer(Licenses licenseKey);
    }
}