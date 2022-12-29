using License_API.Entities;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore;

namespace License_API.Repos
{
    public class KeysInMySql : IKeysInMem
    {
        public MySqlConnection mySQLConn;
                
        public KeysInMySql(string Connection)
        {
            mySQLConn = new MySqlConnection(Connection);
        }
        
        public void CreateKey(LicenseKey licenseKey)
        {
            mySQLConn.Open();
            string query = "INSERT INTO licenses VALUES('" + licenseKey.Id.ToString().Trim() + "', '" + licenseKey.Creation.DateTime + "', '" +
                licenseKey.Category.ToString().Trim() + "', '" + licenseKey.Expiration.DateTime + "', '" + licenseKey.Org_ID.ToString().Trim() + "');";
            MySqlCommand cmm = new MySqlCommand(query, mySQLConn);
            cmm.ExecuteNonQuery();
            mySQLConn.Close();
        }

        public LicenseKey GetKey(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LicenseKey> GetKeys()
        {
            throw new NotImplementedException();
        }

        public void UpdateKey(LicenseKey licenseKey)
        {
            throw new NotImplementedException();
        }
    }
}
