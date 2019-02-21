using CodeDyno.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CodeDyno.Common.Configuration
{
    public class AppConfig : IAppConfig
    {
        private IConfigurationRoot _configuration;

        private readonly IRepositoryConfig _repositoryConfig;
        private readonly IDatabaseConfig _databaseConfig;

        public AppConfig()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            _repositoryConfig = new RepositoryConfig
            {
                LocalRepositoryPath = _configuration["RepositoryConfig:LocalRepositoryPath"],
                RepositoryAddress = _configuration["RepositoryConfig:RepositoryAddress"]
            };

            _databaseConfig = new DatabaseConfig
            {
                ConnectionString = _configuration["DatabaseConfig:ConnectionString"]
            };
        }

        public IRepositoryConfig RepositoryConfig => _repositoryConfig;

        public IDatabaseConfig DatabaseConfig => _databaseConfig;
    }
}