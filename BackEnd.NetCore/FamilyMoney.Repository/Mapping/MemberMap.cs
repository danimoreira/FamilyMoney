using Dapper.FluentMap.Dommel.Mapping;
using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Repository.Mapping
{
    public class MemberMap : DommelEntityMap<Member>
    {
        public MemberMap()
        {
            ToTable("member");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.IdFamily).ToColumn("IdFamily");
            Map(x => x.Name).ToColumn("Name");
            Map(x => x.Username).ToColumn("Username");
            Map(x => x.Role).ToColumn("Role");
            Map(x => x.Password).ToColumn("Password");
            Map(x => x.DateCreate).ToColumn("DateCreate");
            Map(x => x.UserCreate).ToColumn("UserCreate");
            Map(x => x.DateLastUpdate).ToColumn("DateLastUpdate");
            Map(x => x.UserUpdate).ToColumn("UserUpdate");
            Map(x => x.Active).ToColumn("Active");
        }
    }
}