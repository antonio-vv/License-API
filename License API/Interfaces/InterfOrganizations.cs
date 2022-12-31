using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfOrganizations
    {
        Organizations GetOrg(string id);

        void CreateOrg(Organizations org);
    }
}
