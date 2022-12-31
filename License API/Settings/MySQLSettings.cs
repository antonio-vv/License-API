namespace License_API.Settings
{
    public class MySQLSettings
    {
        public string Host { get; set; }

        public string DataBase { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Connection
        {
            get
            {
                return "server = " + Host + "; database=" + DataBase + "; user=" + User + "; password=" + Password + "";
            }
        }
    }
}
