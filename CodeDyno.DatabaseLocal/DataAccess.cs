using System;
using System.Collections.Generic;
using LiteDB;

namespace CodeDyno.DatabaseLocal
{
    public class DataAccess : IDataAccess
    {
        private readonly string _localDatabaseConnectionString;

        public DataAccess(string localDatabaseConnectionString)
        {
            _localDatabaseConnectionString = localDatabaseConnectionString;
        }

        public void Insert<T>(T entity) where T : IEntity
        {
            try
            {
                using (var db = new LiteDatabase(_localDatabaseConnectionString))
                {
                    var dbCollection = db.GetCollection<T>();
                    dbCollection.Insert(entity);
                    dbCollection.EnsureIndex(e => e.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert<T>(IEnumerable<T> entities) where T : IEntity
        {
            try
            {
                using (var db = new LiteDatabase(_localDatabaseConnectionString))
                {
                    var dbCollection = db.GetCollection<T>();
                    dbCollection.Insert(entities);
                    dbCollection.EnsureIndex(e => e.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}