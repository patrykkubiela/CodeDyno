using System.Collections.Generic;

namespace CodeDyno.DatabaseLocal
{
    public interface IDataAccess
    {
        void Insert<T>(T entity) where T : IEntity;
        void Insert<T>(IEnumerable<T> entities) where T : IEntity;
    }
}