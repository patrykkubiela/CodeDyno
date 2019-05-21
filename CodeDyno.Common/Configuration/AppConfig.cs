using System;
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
                RepositoryAddress = _configuration["RepositoryConfig:RepositoryAddress"],
                RepositoryUserName = _configuration["RepositoryConfig:RepositoryUserName"],
                RepositoryUserPassword = _configuration["RepositoryConfig:RepositoryUserPassword"]
            };

            _databaseConfig = new DatabaseConfig
            {
                DefaultConnectionString = _configuration["DatabaseConfig:ConnectionString"],
                ConnectionString = Environment.CurrentDirectory + $"\\LocalDatabase.db"
            };
        }

        public IRepositoryConfig RepositoryConfig => _repositoryConfig;

        public IDatabaseConfig DatabaseConfig => _databaseConfig;
    }
}