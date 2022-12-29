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

        public OrganizationController(InterfOrganizations repo)
        {
            this.repo = repo;
        }

        // GET /Organizations/{id}
        [HttpGet("{id}")]
        public ActionResult<OrganizationsDTO> GetOrg(Guid id)
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
                OrgID = Guid.NewGuid(),
                Organization = noDTO.Organization,
                RUC = noDTO.RUC,
                ZipCode= noDTO.ZipCode,
            };

            repo.CreateOrg(org);
            return CreatedAtAction(nameof(GetOrg), new { OrgID = org.OrgID }, org.AsDTO());
        }
    }
}
