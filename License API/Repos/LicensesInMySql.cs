using License_API.Entities;
using License_API.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace License_API.Repos
{
    public class LicensesInMySql : InterfLicenses
    {
        public MySqlConnection mySQLConn;
                
        public LicensesInMySql(MySqlConnection conn)
        {
            mySQLConn = conn;
        }
        
        public void CreateKey(LicenseKey licenseKey)
        {
            string query = "INSERT INTO licenses VALUES('" + licenseKey.Id.ToString().Trim() + "', '" + 
                licenseKey.Creation.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + licenseKey.Category.Trim() + "', '" + 
                licenseKey.Expiration.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + licenseKey.Org_ID.Trim() + "');";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public LicenseKey GetKey(Guid id)
        {
            string query = "SELECT * FROM licenses WHERE LicKey = '" + id.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            return new LicenseKey
            {
                Id = new Guid(dt.Rows[0][0].ToString().Trim()),
                Creation = Convert.ToDateTime(dt.Rows[0][1].ToString()),
                Category = dt.Rows[0][2].ToString(),
                Expiration = Convert.ToDateTime(dt.Rows[0][3].ToString()),
                Org_ID = dt.Rows[0][4].ToString()
            };
        }

        public void UpgradeKey(LicenseKey licenseKey)
        {
            string query = "UPDATE licenses SET Category = '" + licenseKey.Category.Trim() + "' WHERE LicKey = '" + licenseKey.Id.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void RenewKey(LicenseKey licenseKey)
        {
            string query = "UPDATE licenses SET Expiration = '" + licenseKey.Expiration.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + 
                "' WHERE LicKey = '" + licenseKey.Id.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }
    }
}
