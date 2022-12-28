using License_API.DTOs;
using License_API.Entities;
using License_API.Repos;
using Microsoft.AspNetCore.Mvc;

namespace License_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseKeyController : Controller
    {
        private readonly IKeysInMem repo;

        public LicenseKeyController(IKeysInMem repo)
        {
            this.repo = repo;
        }

        // GET /LicenseKey
        [HttpGet]
        public IEnumerable<LicenseKeyDTO> GetLicenses()
        {
            var lks = repo.GetKeys().Select(lic => lic.AsDTO());

            return lks;
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
            LicenseKey lk = new()
            {
                Id = Guid.NewGuid(),
                Creation = DateTimeOffset.UtcNow,
                Category = nkDTO.Category,
                Expiration = DateTimeOffset.UtcNow.AddMonths(12),
            };
            
            repo.CreateKey(lk);
            return CreatedAtAction(nameof(GetKey), new { id = lk.Id }, lk.AsDTO());
        }

        // PUT /LicenseKey/{id}
        [HttpPut("{id}")]
        public ActionResult<LicenseKeyDTO> UpdateKey(Guid id, UpdateKeyDTO ukDTO)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            LicenseKey upKey = exKey with
            {
                Category = ukDTO.Category,
                Expiration = DateTimeOffset.UtcNow.AddMonths(12),
            };

            repo.UpdateKey(upKey);
            return NoContent();
        }
    }
}
