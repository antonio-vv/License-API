namespace License_API.Entities
{
    public class Server
    {
        public Guid ServID { get; init; }

        public int CreateOps { get; init; }

        public int UpdateOps { get; init; }

        public int AddOps { get; init; }
        
        public int DeleteOps { get; init; }
        
        public string Lic_Key { get; init; }
    }
}
