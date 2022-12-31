using License_API.DTOs;
using License_API.Entities;
using License_API.Interfaces;
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
        public ActionResult<ServersDTO> GetServer(string id)
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
            LicenseKey lk = repoLic.GetKey(nsDTO.Lic_Key);
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
            return CreatedAtAction(nameof(GetServer), new { id = srvr.ServID }, srvr.AsDTO());
        }

        // PUT /Server/{id}/License
        [HttpPut("{id}/License")]
        public ActionResult<LicenseSrvrDTO> LicenseServer(string id, LicenseSrvrDTO lsDTO)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            Server LicSrvr = new()
            {
                ServID = exSrvr.ServID,
                CreateOps = exSrvr.CreateOps,
                UpdateOps = exSrvr.UpdateOps,
                AddOps = exSrvr.AddOps,
                DeleteOps = exSrvr.DeleteOps,
                Lic_Key = lsDTO.Lic_Key,
            };

            repo.LicenseServer(LicSrvr);
            return NoContent();
        }

        // PUT /Server/{id}/Unlicense
        [HttpPut("{id}/Unlicense")]
        public ActionResult<LicenseSrvrDTO> UnlicenseServer(string id)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            repo.UnlicenseServer(exSrvr);
            return NoContent();
        }

        // PUT /Server/{id}/CreateOps
        [HttpPut("{id}/CreateOps")]
        public ActionResult<LicenseSrvrDTO> CreateCount(string id)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            repo.CreateCount(exSrvr);
            return NoContent();
        }

        // PUT /Server/{id}/UpdateOps
        [HttpPut("{id}/UpdateOps")]
        public ActionResult<LicenseSrvrDTO> UpdateCount(string id)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            repo.UpdateCount(exSrvr);
            return NoContent();
        }

        // PUT /Server/{id}/AddOps
        [HttpPut("{id}/AddOps")]
        public ActionResult<LicenseSrvrDTO> AddCount(string id)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            repo.AddCount(exSrvr);
            return NoContent();
        }

        // PUT /Server/{id}/DeleteOps
        [HttpPut("{id}/DeleteOps")]
        public ActionResult<LicenseSrvrDTO> DeleteCount(string id)
        {
            var exSrvr = repo.GetServer(id);
            if (exSrvr is null)
            {
                return NotFound();
            }

            repo.DeleteCount(exSrvr);
            return NoContent();
        }
    }
}
