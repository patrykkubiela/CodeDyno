namespace CodeDyno.Common.Interfaces
{
    public interface IRepositoryConfig
    {
        string RepositoryAddress { get; set; }
        string LocalRepositoryPath { get; set; }
    }
}