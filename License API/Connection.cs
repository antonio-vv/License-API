using System.Data.SqlClient;

namespace License_API
{
    public class Connection
    {
        public static SqlConnection SQLCon = new(@"server = localhost; database=licensesch; user=root; password=Ant/08062000");
    }
}
