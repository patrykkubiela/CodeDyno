namespace CodeDyno.Common.Configuration
{
    public class DatabaseConfig : IDatabaseConfig
    {
        public string DefaultConnectionString { get; set; }
        public string ConnectionString { get; set; }
    }
}