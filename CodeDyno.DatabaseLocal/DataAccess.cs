using System;
using System.Collections.Generic;
using CodeDyno.Common.Interfaces;
using LiteDB;

namespace CodeDyno.DatabaseLocal
{
    public class DataAccess : IDataAccess
    {
        private readonly IAppConfig _configuration;
        private readonly string _localDatabaseConnectionString;

        public DataAccess(IAppConfig configuration)
        {
            _configuration = configuration;
            _localDatabaseConnectionString = _configuration.DatabaseConfig.ConnectionString;
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
        
        public IEnumerable<T> GetEntities<T>() where T : IEntity
        {
            try
            {
                using (var db = new LiteDatabase(_localDatabaseConnectionString))
                {
                    var dbCollection = db.GetCollection<T>();
                    return dbCollection.FindAll();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}