using License_API.DTOs;
using License_API.Entities;
using License_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace License_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : Controller
    {
        private readonly InterfLicenses repo;

        public LicenseController(InterfLicenses repo)
        {
            this.repo = repo;
        }

        // GET /LicenseKey/{id}
        [HttpGet("{id}")]
        public ActionResult<LicenseKeyDTO> GetKey(Guid id)
        {
            var lk = repo.GetKey(id);
            if(lk is null)
            {
                return NotFound();
            }
            else
            {
                return lk.AsDTO();
            }
        }

        // POST /LicenseKey
        [HttpPost]
        public ActionResult<LicenseKeyDTO> CreateKey(NewKeyDTO nkDTO)
        {
            Licenses lk = new()
            {
                Key = Guid.NewGuid(),
                Creation = DateTimeOffset.UtcNow,
                Category = nkDTO.Category,
                Expiration = DateTimeOffset.UtcNow.AddMonths(12),
                Org_ID = nkDTO.Org_ID,
            };
            
            repo.CreateKey(lk);
            return CreatedAtAction(nameof(GetKey), new { id = lk.Key }, lk.AsDTO());
        }

        // PUT /LicenseKey/{id}/Upgrade
        [HttpPut("{id}/Upgrade")]
        public ActionResult<LicenseKeyDTO> UpgradeKey(Guid id, UpgradeKeyDTO ukDTO)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            Licenses upKey = exKey with
            {
                Category = ukDTO.Category,
            };

            repo.UpgradeKey(upKey);
            return NoContent();
        }

        // PUT /LicenseKey/{id}/Renewal
        [HttpPut("{id}/Renewal")]
        public ActionResult<LicenseKeyDTO> RenewKey(Guid id, RenewKeyDTO rkDTO)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            Licenses reKey = exKey with
            {
                Expiration = rkDTO.Expiration,
            };

            repo.RenewKey(reKey);
            return NoContent();
        }
    }
}
