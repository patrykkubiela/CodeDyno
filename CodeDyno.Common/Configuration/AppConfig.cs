using CodeDyno.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CodeDyno.Common.Configuration
{
    public class AppConfig : IAppConfig
    {
        private IConfigurationRoot _configuration;

        private IRepositoryConfig _repositoryConfig;

        public AppConfig()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json.config", optional: true)
                .Build();

            _repositoryConfig = new RepositoryConfig
            {
                LocalRepositoryPath = _configuration["RepositoryConfig:LocalRepositoryPath"],
                RepositoryAddress = _configuration["RepositoryConfig:RepositoryAddress"]
            };
        }

        public IRepositoryConfig RepositoryConfig => _repositoryConfig;
    }
}