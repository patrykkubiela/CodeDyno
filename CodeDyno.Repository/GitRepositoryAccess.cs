using LibGit2Sharp;
using CodeDyno.Common;
using System;
using CodeDyno.Repository.Interfaces;

namespace CodeDyno.Repository
{
    public class GitRepositoryAccess : IRepositoryAccess<Branch>
    {
        private readonly string _localRepositoryPath;
        private readonly CloneOptions _cloneOptions;
        
        public Branch CheckoutedBranch { get; private set; }

        public GitRepositoryAccess(Uri localRepositoryPath, CloneOptions cloneOptions = null)
        {
            if (cloneOptions == null)
            {
                _cloneOptions = new CloneOptions();
                _cloneOptions.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials
                {
                    //TODO get this options from default configuration file
                    Username = "user",
                    Password = "password"
                };
            }
            
            if (localRepositoryPath == null)
                throw new ArgumentNullException(CommonExtensions.GetParameterName<Uri>(() => localRepositoryPath));

            _localRepositoryPath = localRepositoryPath.AbsolutePath;
        }

        public void Checkout(string identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException(CommonExtensions.GetParameterName<string>(() => identifier));

            using (var repository = new LibGit2Sharp.Repository(_localRepositoryPath))
            {
                var branch = repository.Branches[identifier];
                if (branch != null)
                {
                    CheckoutedBranch = Commands.Checkout(repository, identifier);
                }
            }
        }

        public void Clone(string repositoryAddress)
        {
            //"https://github.com/programistadoswiadczony/VSPerformanceProfilerTest.git"
            try
            {
                LibGit2Sharp.Repository.Clone(repositoryAddress, _localRepositoryPath, _cloneOptions);
            }
            catch (NameConflictException exception)
            {
                throw exception;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}