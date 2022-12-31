namespace License_API.Entities
{
    public class Server
    {
        public string ServID { get; init; }

        public int CreateOps { get; init; }

        public int UpdateOps { get; init; }

        public int AddOps { get; init; }
        
        public int DeleteOps { get; init; }
        
        public Guid? Lic_Key { get; init; }
    }
}
