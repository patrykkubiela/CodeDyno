using LibGit2Sharp;
using CodeDyno.Common;
using System;
using CodeDyno.Repository.Interfaces;
using System.Linq;

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
                var branchName = "origin/" + identifier;
                var branch = repository.Branches.FirstOrDefault(b => b.FriendlyName == branchName);
                if (branch != null)
                {
                    CheckoutedBranch = Commands.Checkout(repository, branch);
                }
            }
        }

        public void Clone(string repositoryAddress)
        {
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