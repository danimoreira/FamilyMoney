using Dapper.FluentMap.Dommel.Mapping;
using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Repository.Mapping
{
    public class FamilyMap : DommelEntityMap<Family>
    {
        public FamilyMap()
        {
            ToTable("family");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Name).ToColumn("Name");
            Map(x => x.DateCreate).ToColumn("DateCreate");
            Map(x => x.UserCreate).ToColumn("UserCreate");
            Map(x => x.DateLastUpdate).ToColumn("DateLastUpdate");
            Map(x => x.UserUpdate).ToColumn("UserUpdate");
            Map(x => x.Active).ToColumn("Active");
        }
    }
}