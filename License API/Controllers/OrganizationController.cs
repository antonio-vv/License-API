using License_API.DTOs;
using License_API.Entities;
using License_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace License_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private readonly InterfOrganizations repo;
        private readonly InterfLicenses repoLic;

        public OrganizationController(InterfOrganizations repo, InterfLicenses repoLic)
        {
            this.repo = repo;
            this.repoLic = repoLic;
        }

        // GET /Organizations/{id}
        [HttpGet("{id}")]
        public ActionResult<OrganizationsDTO> GetOrg(string id)
        {
            var org = repo.GetOrg(id);
            if (org is null)
            {
                return NotFound();
            }
            else
            {
                return org.AsDTO();
            }
        }

        // POST /Organizations
        [HttpPost]
        public ActionResult<OrganizationsDTO> CreateOrg(NewOrgDTO noDTO)
        {
            Organizations org = new()
            {
                OrgID = noDTO.ZipCode + "-" + noDTO.RUC,
                Organization = noDTO.Organization,
                RUC = noDTO.RUC,
                ZipCode= noDTO.ZipCode,
            };

            if (repo.CreateOrg(org))
            {
                return CreatedAtAction(nameof(GetOrg), new { id = org.OrgID }, org.AsDTO());
            }
            else
            {
                return BadRequest();
            }
            
        }

        // GET /Organizations/{id}/Licenses
        [HttpGet("{id}/Licenses")]
        public IEnumerable<Licenses> GetOrgLics(string id)
        {
            var lics = repoLic.GetOrgLics(id);
            return lics;
        }
    }
}
