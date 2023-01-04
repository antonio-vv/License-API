using License_API.Entities;

namespace License_API.Interfaces
{
    public interface InterfOrganizations
    {
        Organizations GetOrg(string id);

        bool CreateOrg(Organizations org);
    }
}
