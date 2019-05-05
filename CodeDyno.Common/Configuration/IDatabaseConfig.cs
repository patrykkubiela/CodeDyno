namespace CodeDyno.Common.Configuration
{
    public interface IDatabaseConfig
    {
        string DefaultConnectionString { get; set; }
        string ConnectionString { get; set; }
    }
}