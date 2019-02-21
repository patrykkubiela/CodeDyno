namespace CodeDyno.Common.Configuration
{
    public class DatabaseConfig : IDatabaseConfig
    {
        public string ConnectionString { get; set; }
    }

    public interface IDatabaseConfig
    {
        string ConnectionString { get; set; }
    }
}