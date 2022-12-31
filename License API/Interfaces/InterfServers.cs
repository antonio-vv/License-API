using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfServers
    {
        Server GetServer(string id);

        void RegisterServer(Server srvr);

        void CreateCount(Server srvr);

        void UpdateCount(Server srvr);

        void AddCount(Server srvr);

        void DeleteCount(Server srvr);

        void LicenseServer(Server srvr);

        void UnlicenseServer(Server srvr);
    }
}
