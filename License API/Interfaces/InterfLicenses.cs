using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfLicenses
    {
        LicenseKey GetKey(Guid id);

        void CreateKey(LicenseKey licenseKey);

        void UpgradeKey(LicenseKey licenseKey);

        void RenewKey(LicenseKey licenseKey);
    }
}