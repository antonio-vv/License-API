using License_API.Entities;
using License_API.Repos;
using Microsoft.AspNetCore.Mvc;

namespace License_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseKeyController : Controller
    {
        private readonly KeysInMem repo;

        public LicenseKeyController()
        {
            repo = new KeysInMem();
        }

        [HttpGet]
        public IEnumerable<LicenseKey> GetLicenses()
        {
            var keys = repo.GetKeys();

            return keys;
        }

        [HttpGet]
        public IEnumerable<LicenseKey> GetLicense()
        {
            var key = repo.GetKeys();
            return key;
        }
    }
}
