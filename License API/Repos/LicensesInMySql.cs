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
        
        public void CreateKey(Licenses licenseKey)
        {
            string query = "INSERT INTO license VALUES('" + licenseKey.Key.ToString().Trim() + "', '" + 
                licenseKey.Creation.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + licenseKey.Category.Trim() + "', '" + 
                licenseKey.Expiration.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + licenseKey.Org_ID.Trim() + "');";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public Licenses GetKey(Guid id)
        {
            string query = "SELECT * FROM license WHERE LicKey = '" + id.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            return new Licenses
            {
                Key = new Guid(dt.Rows[0][0].ToString().Trim()),
                Creation = Convert.ToDateTime(dt.Rows[0][1].ToString()),
                Category = dt.Rows[0][2].ToString(),
                Expiration = Convert.ToDateTime(dt.Rows[0][3].ToString()),
                CreateOps = Convert.ToInt32(dt.Rows[0][4].ToString()),
                UpdateOps = Convert.ToInt32(dt.Rows[0][5].ToString()),
                AddOps = Convert.ToInt32(dt.Rows[0][6].ToString()),
                DeleteOps = Convert.ToInt32(dt.Rows[0][7].ToString()),
                Server = dt.Rows[0][8].ToString(),
                Org_ID = dt.Rows[0][9].ToString()
            };
        }

        public void UpgradeKey(Licenses licenseKey)
        {
            string query = "UPDATE license SET Category = '" + licenseKey.Category.Trim() + "' WHERE LicKey = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void RenewKey(Licenses licenseKey)
        {
            string query = "UPDATE license SET Expiration = '" + licenseKey.Expiration.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + 
                "' WHERE LicKey = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }
    }
}
