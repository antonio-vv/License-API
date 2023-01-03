using License_API.Entities;
using License_API.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml.Linq;

namespace License_API.Repos
{
    public class CategoriesInMySql : InterfCategories
    {
        public MySqlConnection mySQLConn;

        public CategoriesInMySql(MySqlConnection conn)
        {
            mySQLConn = conn;
        }

        public void CreateCat(Categories cat)
        {
            string query = "INSERT INTO category VALUES('" + cat.Name.Trim() + "', " + cat.Creations + ", " + cat.Updates + ", " +
                cat.Additions + ", " + cat.Deletions + ");";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }

        public Categories GetCat(string name)
        {
            string query = "SELECT * FROM category WHERE name = '" + name.Trim() + "';";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            Categories cat = new()
            {
                Name = dt.Rows[0][0].ToString().Trim(),
                Creations = Convert.ToInt32(dt.Rows[0][1].ToString().Trim()),
                Updates = Convert.ToInt32(dt.Rows[0][2].ToString().Trim()),
                Additions = Convert.ToInt32(dt.Rows[0][3].ToString().Trim()),
                Deletions = Convert.ToInt32(dt.Rows[0][4].ToString().Trim())
            };

            return cat;
        }

        public IEnumerable<Categories> GetCats()
        {
            string query = "SELECT * FROM category;";
            MySqlCommand cmm = new(query, mySQLConn);
            MySqlDataAdapter adp = new(cmm);
            DataTable dt = new();
            adp.Fill(dt);

            var cats = new List<Categories>();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                var cat = new Categories()
                {
                    Name = dt.Rows[i][0].ToString().Trim(),
                    Creations = Convert.ToInt32(dt.Rows[i][1].ToString().Trim()),
                    Updates = Convert.ToInt32(dt.Rows[i][2].ToString().Trim()),
                    Additions = Convert.ToInt32(dt.Rows[i][3].ToString().Trim()),
                    Deletions = Convert.ToInt32(dt.Rows[i][4].ToString().Trim())
                };
                cats.Add(cat);
            }

            return cats;
        }

        public void UpdateCat(Categories cat)
        {
            string query = "UPDATE category SET creations = " + cat.Creations + ", updates = " + cat.Updates + ", additions = " + cat.Additions +
                ", deletions = " + cat.Deletions + " WHERE name = '" + cat.Name + "'";
            MySqlCommand cmm = new(query, mySQLConn);
            cmm.ExecuteNonQuery();
        }
    }
}
