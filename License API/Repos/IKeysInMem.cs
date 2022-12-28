using License_API.Entities;

namespace License_API.Repos
{
    public interface IKeysInMem
    {
        LicenseKey GetKey(Guid id);
        
        IEnumerable<LicenseKey> GetKeys();

        void CreateKey(LicenseKey licenseKey);

        void UpdateKey(LicenseKey licenseKey);
    }
}
