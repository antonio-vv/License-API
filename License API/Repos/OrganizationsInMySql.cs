using License_API.Entities;
using License_API.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace License_API.Repos
{
    public class OrganizationsInMySql : InterfOrganizations
    {
        public MySqlConnection mySQLConn;

        public OrganizationsInMySql(MySqlConnection conn)
        {
            mySQLConn = conn;
        }

        public void CreateOrg(Organizations org)
        {
            string query = "INSERT INTO organizations VALUES('" + org.OrgID.ToString().Trim() + "', '" + org.Organization.Trim() + "', '" +
                org.RUC.Trim() + "', '" + org.ZipCode.Trim() + "');";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public Organizations GetOrg(Guid id)
        {
            string query = "SELECT * FROM organizations WHERE OrgID = '" + id.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            return new Organizations
            {
                OrgID = new Guid(dt.Rows[0][0].ToString().Trim()),
                Organization = dt.Rows[0][1].ToString().Trim(),
                RUC = dt.Rows[0][2].ToString().Trim(),
                ZipCode = dt.Rows[0][3].ToString().Trim(),
            };
        }
    }
}
