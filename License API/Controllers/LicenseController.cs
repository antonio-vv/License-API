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
        private readonly InterfCategories repoCat;
        private readonly InterfOrganizations repoOrg;

        public LicenseController(InterfLicenses repo, InterfCategories repoCat, InterfOrganizations repoOrg)
        {
            this.repo = repo;
            this.repoCat = repoCat;
            this.repoOrg = repoOrg;
        }

        // GET /License/{id}
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

        // POST /License
        [HttpPost]
        public ActionResult<LicenseKeyDTO> CreateKey(NewKeyDTO nkDTO)
        {
            Categories cat = repoCat.GetCat(nkDTO.Category);
            Organizations org = repoOrg.GetOrg(nkDTO.Org_ID);
            if (cat is null | org is null)
            {
                return BadRequest();
            }
            else
            {
                Licenses lk = new()
                {
                    Key = Guid.NewGuid(),
                    Creation = DateTimeOffset.UtcNow,
                    Category = nkDTO.Category,
                    Expiration = DateTimeOffset.UtcNow.AddMonths(12),
                    CreateOps = cat.Creations,
                    UpdateOps = cat.Updates,
                    AddOps = cat.Additions,
                    DeleteOps = cat.Deletions,
                    Server = nkDTO.Server,
                    Org_ID = nkDTO.Org_ID,
                };

                if (repo.CreateKey(lk))
                {
                    return CreatedAtAction(nameof(GetKey), new { id = lk.Key }, lk.AsDTO());
                }
                else
                {
                    return BadRequest();
                }                
            }
        }

        // PUT /License/{id}/Upgrade
        [HttpPut("{id}/Upgrade")]
        public ActionResult<LicenseKeyDTO> UpgradeKey(Guid id, UpgradeKeyDTO ukDTO)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            if (repoCat.GetCat(ukDTO.Category) is null)
            {
                return BadRequest();
            }
            else
            {
                Licenses upKey = exKey with
                {
                    Category = ukDTO.Category,
                };

                if (repo.UpgradeKey(upKey))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            
        }

        // PUT /License/{id}/Renewal
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

            if (repo.RenewKey(reKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT /License/{id}/Creation
        [HttpPut("{id}/Creation")]
        public ActionResult<LicenseKeyDTO> CreateCount(Guid id)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            if (repo.CreateCount(exKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
            
        }

        // PUT /License/{id}/Update
        [HttpPut("{id}/Update")]
        public ActionResult<LicenseKeyDTO> UpdateCount(Guid id)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }
            
            if (repo.UpdateCount(exKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT /License/{id}/Addition
        [HttpPut("{id}/Addition")]
        public ActionResult<LicenseKeyDTO> AddCount(Guid id)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            if (repo.AddCount(exKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT /License/{id}/Deletion
        [HttpPut("{id}/Deletion")]
        public ActionResult<LicenseKeyDTO> DeleteCount(Guid id)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            if (repo.DeleteCount(exKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT /License/{id}/Bind
        [HttpPut("{id}/Bind")]
        public ActionResult<LicenseKeyDTO> BindServer(Guid id, BindKeyDTO bkDTO)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            Licenses reKey = exKey with
            {
                Server = bkDTO.Server,
            };

            if (repo.BindServer(reKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT /License/{id}/Unbind
        [HttpPut("{id}/Unbind")]
        public ActionResult<LicenseKeyDTO> UnbindServer(Guid id)
        {
            var exKey = repo.GetKey(id);
            if (exKey is null)
            {
                return NotFound();
            }

            if (repo.UnbindServer(exKey))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}