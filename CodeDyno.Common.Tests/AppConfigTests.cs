using System;
using System.Collections.Generic;
using CodeDyno.Common.Interfaces;
using Xunit;

namespace CodeDyno.Common.Tests
{
    public class AppConfigTests
    {
        private readonly IAppConfig _appConfig;

        public AppConfigTests(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        [Fact]
        public void DefaultConfigValues_Repository_OK()
        {
            var expectedRepositoryAddress = "";
            var expectedLocalRepositoryPath = "";
            var expectedRepositoryUserName = "";
            var expectedRepositoryUserPassword = "";
            
            Assert.Equal(expectedRepositoryAddress, _appConfig.RepositoryConfig.RepositoryAddress);
            Assert.Equal(expectedRepositoryAddress, _appConfig.RepositoryConfig.LocalRepositoryPath);
            Assert.Equal(expectedRepositoryAddress, _appConfig.RepositoryConfig.RepositoryUserName);
            Assert.Equal(expectedRepositoryAddress, _appConfig.RepositoryConfig.RepositoryUserPassword);
        }
        
        [Fact]
        public void DefaultConfigValues_Database_OK()
        {
            var expectedConnectionString = "";
            var defaultConnectionString = "";
            
            Assert.Equal(expectedConnectionString, _appConfig.DatabaseConfig.ConnectionString);
            Assert.Equal(expectedConnectionString, _appConfig.DatabaseConfig.DefaultConnectionString);
        }
    }
}
