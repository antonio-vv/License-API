using License_API.Entities;
using License_API.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace License_API.Repos
{
    public class ServersInMySql : InterfServers
    {
        public MySqlConnection mySQLConn;

        public ServersInMySql(MySqlConnection conn)
        {
            mySQLConn = conn;
        }

        public void AddCount(Server srvr)
        {
            string query = "UPDATE severs SET AddOps = AddOps - 1 WHERE ServerID = '" + srvr.ServID.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void CreateCount(Server srvr)
        {
            string query = "UPDATE severs SET CreateOps = AddOps - 1 WHERE ServerID = '" + srvr.ServID.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void DeleteCount(Server srvr)
        {
            string query = "UPDATE severs SET DeleteOps = AddOps - 1 WHERE ServerID = '" + srvr.ServID.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public Server GetServer(Guid id)
        {
            string query = "SELECT * FROM organizations WHERE OrgID = '" + id.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            return new Server
            {
                ServID = new Guid(dt.Rows[0][0].ToString().Trim()),
                CreateOps = Convert.ToInt32(dt.Rows[0][1].ToString()),
                UpdateOps = Convert.ToInt32(dt.Rows[0][2].ToString().Trim()),
                AddOps = Convert.ToInt32(dt.Rows[0][3].ToString().Trim()),
                DeleteOps = Convert.ToInt32(dt.Rows[0][4].ToString().Trim()),
                Lic_Key = dt.Rows[0][5].ToString().Trim(),
            };
        }

        public void LicenseServer(Server srvr)
        {
            string query = "UPDATE severs SET Lic_Key = '" + srvr.Lic_Key.Trim() + "' WHERE ServerID = '" + srvr.ServID.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void RegisterServer(Server srvr)
        {
            string query = "INSERT INTO servers VALUES('" + srvr.ServID.ToString().Trim() + "', " + srvr.CreateOps + ", " +
                srvr.UpdateOps + ", " + srvr.AddOps + ", " + srvr.DeleteOps + ", '" + srvr.Lic_Key + "');";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void UnlicenseServer(Server srvr)
        {
            string query = "UPDATE severs SET Lic_Key = '' WHERE ServerID = '" + srvr.ServID.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void UpdateCount(Server srvr)
        {
            string query = "UPDATE severs SET UpdateOps = AddOps - 1 WHERE ServerID = '" + srvr.ServID.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }
    }
}
