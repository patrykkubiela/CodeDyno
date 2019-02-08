using System;
using System.IO;
using System.Linq;
using CodeDyno.Common.Interfaces;
using LibGit2Sharp;
using Xunit;

namespace CodeDyno.Repository.Tests
{
    public class GitRepositoryAccessTests
    {
        private IRepositoryAccess<Branch> _gitRepositoryAccess;

        [Fact]
        public void GitClone_Clone_OK()
        {
            var testDirectoryPath = Environment.CurrentDirectory + $"\\{Guid.NewGuid().ToString()}";
            Directory.CreateDirectory(testDirectoryPath);

            var uri = new Uri(testDirectoryPath);
            var repositoryAddress = "https://github.com/programistadoswiadczony/PythonWebApi.git";
            _gitRepositoryAccess = new GitRepositoryAccess(uri);

            //act
            _gitRepositoryAccess.Clone(repositoryAddress);

            Assert.True(Directory.GetFiles(testDirectoryPath).Any());
        }

        [Fact]
        public void GitClone_ThrowNameConflictException()
        {
            var uri = new Uri(Environment.CurrentDirectory);
            var repositoryAddress = "";
            _gitRepositoryAccess = new GitRepositoryAccess(uri);

            Action testCode = () => _gitRepositoryAccess.Clone(repositoryAddress);

            //comment
            Assert.Throws<NameConflictException>(testCode);
        }

        [Fact]
        public void GtiCheckout_CheckoutProperBranch_OK()
        {
            var testDirectoryPath = Environment.CurrentDirectory + $"\\{Guid.NewGuid().ToString()}";
            Directory.CreateDirectory(testDirectoryPath);

            var uri = new Uri(testDirectoryPath);
            var repositoryAddress = "https://github.com/programistadoswiadczony/PythonWebApi.git";
            _gitRepositoryAccess = new GitRepositoryAccess(uri);

            _gitRepositoryAccess.Clone(repositoryAddress);
            var branchName = "master";

            //act
            _gitRepositoryAccess.Checkout(branchName);

            Assert.NotNull(_gitRepositoryAccess.CheckoutedBranch);
            Assert.Equal("HEAD", _gitRepositoryAccess.CheckoutedBranch.Reference.CanonicalName);
        }
    }
}