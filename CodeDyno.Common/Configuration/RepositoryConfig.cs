using CodeDyno.Common.Interfaces;

namespace CodeDyno.Common.Configuration
{
    public class RepositoryConfig : IRepositoryConfig
    {
        public string RepositoryAddress { get; set; }
        public string LocalRepositoryPath { get; set; }
        public string RepositoryUserName { get; set; }
        public string RepositoryUserPassword { get; set; }
    }
}