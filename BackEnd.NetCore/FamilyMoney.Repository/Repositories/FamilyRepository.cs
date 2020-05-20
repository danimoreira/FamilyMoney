using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;

namespace FamilyMoney.Repository.Repositories
{
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public override int Add(Family obj)
        {            
            return _connection.Query<Int32>(@"INSERT INTO family (Name, DateCreate, UserCreate, Active) VALUES (@name, @datecreate, @usercreate, true); select last_insert_rowid()", new { obj.Name, obj.DateCreate, obj.UserCreate }).First();
        }

        public override void Update(Family obj)
        {            
            _connection.Query<Family>(@"UPDATE family SET name = @name, datelastupdate = @datelastupdate, userupdate = @userupdate WHERE id = @id", new { obj.Id, obj.Name, obj.DateLastUpdate, obj.UserUpdate });
        }

        public override void Delete(int id)
        {            
            var obj = _connection.Query<Family>(@"DELETE FROM family WHERE id = @id", new { id });
        }

        public override Family GetById(int id)
        {
            var obj = _connection.Query<Family>(@"SELECT * FROM family WHERE id = @id", new { id }).FirstOrDefault();            
            return obj;
        }

        public override List<Family> GetAll()
        {
            var obj = _connection.Query<Family>(@"SELECT * FROM family").ToList();
            return obj;
        }
    }
}