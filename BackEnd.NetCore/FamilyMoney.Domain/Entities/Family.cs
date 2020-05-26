using System;

namespace FamilyMoney.Domain.Entities
{
    public class Family : BaseEntity
    {
        public Family(string name, string userCreate)
        : base(userCreate)
        {
            this.Name = name;
        }

        protected Family() { }

        public string Name { get; private set; }

        public void Update(string name, string userUpdate)        
        {
            this.Name = name;
            base.Update(userUpdate);
        }
    }
}