using System.Linq;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;

namespace FamilyMoney.Repository.Repositories
{
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public override int Add(Family obj)
        {            
            return 0;
        }

        public override void Update(Family obj)
        {

        }

        public override void Delete(Family obj)
        {

        }

        public override void Save()
        {

        }

        public override Family GetById(int id)
        {
            return null;
        }

        public override IQueryable<Family> GetAll()
        {
            return null;
        }
    }
}