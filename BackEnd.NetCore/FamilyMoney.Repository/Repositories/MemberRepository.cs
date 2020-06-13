using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;

namespace FamilyMoney.Repository.Repositories
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public override int Add(Member obj)
        {
            return _connection.Query<Int32>(@"INSERT INTO member (IdFamily, Name, UserName, Password, Role, DateCreate, UserCreate, Active) VALUES (@idfamily, @name, @username, @password, @role, @datecreate, @usercreate, true); select last_insert_rowid()", new { obj.IdFamily, obj.Name, obj.Username, obj.Password, obj.Role, obj.DateCreate, obj.UserCreate }).First();
        }

        public override void Update(Member obj)
        {
            using (var cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText = @"UPDATE member SET idfamily = @idfamily, name = @name, datelastupdate = @datelastupdate, userupdate = @userupdate WHERE id = @id";
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@idfamily", obj.IdFamily);
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@datelastupdate", obj.DateLastUpdate);
                cmd.Parameters.AddWithValue("@userupdate", obj.UserUpdate);
                cmd.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (var cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText = @"DELETE FROM member WHERE id = @id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public override Member GetById(int id)
        {
            var obj = _connection.Query<Member>(@"SELECT * FROM member WHERE id = @id", new { id }).FirstOrDefault();
            return obj;
        }

        public override IQueryable<Member> GetAll()
        {
            var obj = _connection.Query<Member>(@"SELECT * FROM member").AsQueryable();
            return obj;
        }

        public Member Login(string username, string password)
        {
            var obj = _connection.Query<Member>(@"SELECT * FROM member WHERE username = @username AND password = @password", new { username, password }).FirstOrDefault();            
            return obj;
        }

    }
}