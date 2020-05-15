using System;

namespace FamilyMoney.Domain.Entities
{
    public class Family : BaseEntity
    {
        private Family(string name, string userCreate) : base(userCreate)
        {
            this.Name = name;
        }

        public string Name { get; private set; }         
    }
}