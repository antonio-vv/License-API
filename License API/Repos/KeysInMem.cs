using License_API.Entities;
using Microsoft.AspNetCore.Http.Features;
using System.Data.SqlClient;

namespace License_API.Repos
{
    public class KeysInMem : IKeysInMem
    {
        private readonly List<LicenseKey> keys = new()
        {
            new LicenseKey{ Id = Guid.NewGuid(), Creation = DateTime.Now, Category = "BOT", Expiration = DateTime.Now.AddMonths(12) },
            new LicenseKey{ Id = Guid.NewGuid(), Creation = DateTime.Now, Category = "HWC", Expiration = DateTime.Now.AddMonths(12) },
            new LicenseKey{ Id = Guid.NewGuid(), Creation = DateTime.Now, Category = "CTX", Expiration = DateTime.Now.AddMonths(12) }
        };

        public IEnumerable<LicenseKey> GetKeys()
        {
            return keys;
        }

        public LicenseKey GetKey(Guid id)
        {
            return keys.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateKey(LicenseKey key)
        {
            SqlConnection SQLConn = Connection.SQLCon;
            SQLConn.Open();
            string query = "INSERT INTO licenses VALUES()";


            SQLConn.Close();
        }

        public void UpdateKey(LicenseKey key)
        {
            var index = keys.FindIndex(exItem => exItem.Id == key.Id);
            keys[index] = key;
        }
    }
}
