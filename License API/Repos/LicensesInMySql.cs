﻿using License_API.Entities;
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
                licenseKey.Expiration.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', " + licenseKey.CreateOps + ", " + licenseKey.UpdateOps +
                ", " + licenseKey.AddOps + ", " + licenseKey.DeleteOps;
            if(licenseKey.Server is null)
            {
                query = query + ", NULL, '" + licenseKey.Org_ID.Trim() + "');";
            }
            else
            {
                query = query + ", '" + licenseKey.Server.Trim() + "', '" + licenseKey.Org_ID.Trim() + "');";
            }
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public Licenses GetKey(Guid id)
        {
            string query = "SELECT * FROM license WHERE key = '" + id.ToString() + "' ;";
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

        public IEnumerable<Licenses> GetOrgLics(string org_id)
        {
            string query = "SELECT * FROM license WHERE OrgID = '" + org_id.Trim() + "' ;";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            var lics = new List<Licenses>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var lic = new Licenses()
                {
                    Key = new Guid(dt.Rows[i][0].ToString()),
                    Creation = Convert.ToDateTime(dt.Rows[i][1].ToString()),
                    Category = dt.Rows[i][2].ToString(),
                    Expiration = Convert.ToDateTime(dt.Rows[i][3].ToString()),
                    CreateOps = Convert.ToInt32(dt.Rows[i][4].ToString()),
                    UpdateOps = Convert.ToInt32(dt.Rows[i][5].ToString()),
                    AddOps = Convert.ToInt32(dt.Rows[i][6].ToString()),
                    DeleteOps = Convert.ToInt32(dt.Rows[i][7].ToString()),
                    Server = dt.Rows[i][8].ToString(),
                    Org_ID = dt.Rows[i][9].ToString()
                };
                lics.Add(lic);
            }

            return lics;
        }

        public void UpgradeKey(Licenses licenseKey)
        {
            string query = "UPDATE license SET category = '" + licenseKey.Category.Trim() + "' WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void RenewKey(Licenses licenseKey)
        {
            string query = "UPDATE license SET expiration = '" + licenseKey.Expiration.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + 
                "' WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void CreateCount(Licenses licenseKey)
        {
            string query = "UPDATE license SET createOps = createOps - 1 WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void UpdateCount(Licenses licenseKey)
        {
            string query = "UPDATE license SET updateOps = updateOps - 1 WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void AddCount(Licenses licenseKey)
        {
            string query = "UPDATE license SET addOps = addOps - 1 WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void DeleteCount(Licenses licenseKey)
        {
            string query = "UPDATE license SET deleteOps = deleteOps - 1 WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void BindServer(Licenses licenseKey)
        {
            string query = "UPDATE license SET server = '" + licenseKey.Server.Trim() + "' WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public void UnbindServer(Licenses licenseKey)
        {
            string query = "UPDATE license SET server = NULL WHERE key = '" + licenseKey.Key.ToString().Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }
    }
}
