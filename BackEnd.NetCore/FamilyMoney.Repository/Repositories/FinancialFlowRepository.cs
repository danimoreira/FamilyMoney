using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;

namespace FamilyMoney.Repository.Repositories
{
    public class FinancialFlowRepository : RepositoryBase<FinancialFlow>, IFinancialFlowRepository
    {
        public override int Add(FinancialFlow obj)
        {
            return _connection.Query<Int32>(@"INSERT INTO financialflow 
            (IdFamily, 
            DateMovement, 
            TypeMovement, 
            TypePayment, 
            ProviderName, 
            IdMemberMovement,
            UrlPaymentVoucher, 
            ValueMovement, 
            SituationMovement, 
            DateCreate, 
            UserCreate, 
            Active ) 
            VALUES 
            (@IdFamily, 
            @DateMovement, 
            @TypeMovement, 
            @TypePayment, 
            @ProviderName, 
            @IdMemberMovement,
            @UrlPaymentVoucher, 
            @ValueMovement, 
            @SituationMovement, 
            @DateCreate, 
            @UserCreate, 
            true); 
            select last_insert_rowid()", new { 
                obj.IdFamily, 
                obj.Movement.DateMovement, 
                obj.Movement.TypeMovement, 
                obj.Movement.TypePayment, 
                obj.Movement.ProviderName, 
                obj.IdMemberMovement,
                obj.Movement.UrlPaymentVoucher, 
                obj.Movement.ValueMovement, 
                obj.Movement.SituationMovement, 
                obj.DateCreate, 
                obj.UserCreate }
            ).First();
        }

        public override void Update(FinancialFlow obj)
        {
            using (var cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText = @"UPDATE financialflow 
                                    SET IdFamily = @IdFamily, 
                                        DateMovement = @DateMovement, 
                                        TypeMovement = @TypeMovement, 
                                        TypePayment = @TypePayment, 
                                        ProviderName = @ProviderName, 
                                        IdMemberMovement = @IdMemberMovement,
                                        UrlPaymentVoucher = @UrlPaymentVoucher, 
                                        ValueMovement = @ValueMovement, 
                                        SituationMovement = @SituationMovement,
                                        datelastupdate = @datelastupdate, 
                                        userupdate = @userupdate 
                                        WHERE id = @id";
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@IdFamily", obj.IdFamily);
                cmd.Parameters.AddWithValue("@DateMovement", obj.Movement.DateMovement);
                cmd.Parameters.AddWithValue("@TypeMovement", obj.Movement.TypeMovement);
                cmd.Parameters.AddWithValue("@TypePayment", obj.Movement.TypePayment);
                cmd.Parameters.AddWithValue("@ProviderName", obj.Movement.ProviderName);
                cmd.Parameters.AddWithValue("@IdMemberMovement", obj.IdMemberMovement);
                cmd.Parameters.AddWithValue("@UrlPaymentVoucher", obj.Movement.UrlPaymentVoucher);
                cmd.Parameters.AddWithValue("@SituationMovement", obj.Movement.SituationMovement);                
                cmd.Parameters.AddWithValue("@datelastupdate", obj.DateLastUpdate);
                cmd.Parameters.AddWithValue("@userupdate", obj.UserUpdate);
                cmd.ExecuteNonQuery();
            }
        }

        public override void Delete(int id)
        {
            using (var cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText = @"DELETE FROM financialflow WHERE id = @id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public override FinancialFlow GetById(int id)
        {
            var obj = _connection.Query<FinancialFlow>(@"SELECT * FROM financialflow WHERE id = @id", new { id }).FirstOrDefault();
            return obj;
        }

        public override IQueryable<FinancialFlow> GetAll()
        {
            var obj = _connection.Query<FinancialFlow>(@"SELECT * FROM financialflow").AsQueryable();
            return obj;
        }
    }
}