using License_API.DTOs;
using License_API.Entities;
using License_API.Interfaces;
using License_API.Repos;
using Microsoft.AspNetCore.Mvc;

namespace License_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : Controller
    {
        private readonly InterfServers repo;
        private readonly InterfLicenses repoLic;

        public ServerController(InterfServers repo, InterfLicenses repo_lic)
        {
            this.repo = repo;
            this.repoLic = repo_lic;
        }

        // GET /Server/{id}
        [HttpGet("{id}")]
        public ActionResult<ServersDTO> GetServer(Guid id)
        {
            var srvr = repo.GetServer(id);
            if (srvr is null)
            {
                return NotFound();
            }
            else
            {
                return srvr.AsDTO();
            }
        }

        // POST /Server
        [HttpPost]
        public ActionResult<NewSrvrDTO> RegisterServer(NewSrvrDTO nsDTO)
        {
            LicenseKey lk = repoLic.GetKey(new Guid(nsDTO.Lic_Key));
            int creation;
            int update;
            int add;
            int delete;
            
            switch (lk.Category)
            {
                case "Bronze":
                    creation = 5;   update = 0; add = 3;    delete = 0;
                    break;
                case "Silver":
                    creation = 10;  update = 3; add = 5;    delete = 5;
                    break;
                case "Gold":
                    creation = 25;  update = 10;    add = 25;   delete = -7;
                    break;
                default:
                    creation = 0;   update = 0; add = 0;    delete = 0;
                    break;
            }

            Server srvr = new()
            {
                ServID = nsDTO.ServID,
                CreateOps = creation,
                UpdateOps = update,
                AddOps = add,
                DeleteOps = delete,
                Lic_Key = nsDTO.Lic_Key,
            };

            repo.RegisterServer(srvr);
            return CreatedAtAction(nameof(GetServer), new { ServID = srvr.ServID }, srvr.AsDTO());
        }

        // PUT /Server/{id}/License
        [HttpPut("{id}/License")]
        public ActionResult<LicenseSrvrDTO> LicenseServer(Guid id, LicenseSrvrDTO lsDTO)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            Server LicSrvr = exSrvr with
            {
                Lic_Key = lsDTO.Lic_Key,
            };

            repo.LicenseServer(LicSrvr);
            return NoContent();
        }

        // PUT /Server/{id}/Unlicense
        [HttpPut("{id}/Unlicense")]
        public ActionResult<LicenseSrvrDTO> UnlicenseServer(Guid id)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            repo.UnlicenseServer(exSrvr);
            return NoContent();
        }
    }
}
