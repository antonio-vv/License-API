using License_API.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace License_API.Repos
{
    public class KeysInMem
    {
        private readonly List<LicenseKey> keys = new()
        {
            new LicenseKey{ Id = Guid.NewGuid(), Organization = "BOT", Server = "Lenovo", Creation = DateTime.Now },
            new LicenseKey{ Id = Guid.NewGuid(), Organization = "HWC", Server = "Huawei", Creation = DateTime.Now },
            new LicenseKey{ Id = Guid.NewGuid(), Organization = "CTX", Server = "VMWare", Creation = DateTime.Now }
        };

        public IEnumerable<LicenseKey> GetKeys()
        {
            return keys;
        }

        public LicenseKey GetKey(Guid id)
        {
            return keys.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}
