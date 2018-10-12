using LibGit2Sharp;
using PerformanceProfileViewer.Common;
using System;

namespace CodeDyno.Repository
{
    public class GitRepositoryAccess
    {
        private readonly string _repositoryPath;

        public GitRepositoryAccess(Uri repositoryPath)
        {
            if (repositoryPath == null)
                throw new ArgumentNullException(CommonExtensions.GetParameterName<Uri>(() => repositoryPath));

            _repositoryPath = repositoryPath.AbsolutePath;
        }

        public Branch Checkout(string branchName)
        {
            if (branchName == null)
                throw new ArgumentNullException(CommonExtensions.GetParameterName<string>(() => branchName));

            using (var repository = new Repository(_repositoryPath))
            {
                var branch = repository.Branches[branchName];
                if (branch != null)
                {
                    branch = Commands.Checkout(repository, branch);
                }

                return branch;
            }
        }

        public void Clone(CloneOptions cloneOptions = null)
        {
            if (cloneOptions == null)
            {
                cloneOptions = new CloneOptions();
                cloneOptions.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials
                {
                    Username = "user",
                    Password = "password"
                };
            }

            //nameconflictexception
            try
            {
                Repository.Clone("https://github.com/programistadoswiadczony/VSPerformanceProfilerTest.git", _repositoryPath, cloneOptions);
            }
            catch (NameConflictException exception)
            {

            }
        }

        public bool IsRepository()
        {
            try
            {
                var repository = new Repository(_repositoryPath);
                return true;
            }
            catch (RepositoryNotFoundException)
            {
                return false;
            }
        }
    }
}
