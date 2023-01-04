using License_API.Entities;
using License_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public bool CreateOrg(Organizations org)
        {
            string query = "INSERT INTO organization VALUES('" + org.OrgID.ToString().Trim() + "', '" + org.Organization.Trim() + "', '" +
                org.RUC.Trim() + "', '" + org.ZipCode.Trim() + "');";
            MySqlCommand cmm = new(query, mySQLConn);
            try
            {
                cmm.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                return false;
            }
        }

        public Organizations GetOrg(string id)
        {
            string query = "SELECT * FROM organization WHERE ID = '" + id.Trim() + "';";
            MySqlDataAdapter adp = new(query, mySQLConn);
            DataTable dt = new();
            adp.Fill(dt);
            try
            {
                return new Organizations
                {
                    OrgID = dt.Rows[0][0].ToString().Trim(),
                    Organization = dt.Rows[0][1].ToString().Trim(),
                    RUC = dt.Rows[0][2].ToString().Trim(),
                    ZipCode = dt.Rows[0][3].ToString().Trim(),
                };
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
