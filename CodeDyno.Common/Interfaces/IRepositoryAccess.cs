namespace CodeDyno.Common.Interfaces
{
    public interface IRepositoryAccess<T>
    {
        T CheckoutedBranch { get; }
        
        void Checkout(string identifier);
        void Clone(string repositoryAddress);
    }
}