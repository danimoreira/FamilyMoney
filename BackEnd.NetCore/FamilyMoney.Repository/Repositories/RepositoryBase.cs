using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;

namespace FamilyMoney.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected static SQLiteConnection _connection;        

        public RepositoryBase()
        {            
            var connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "Database\\familymoney.db";
            _connection = new SQLiteConnection(connectionStringBuilder.ConnectionString);            
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }        

        public virtual int Add(TEntity obj)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Save()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(TEntity obj)
        {
            throw new System.NotImplementedException();
        }
    }
}