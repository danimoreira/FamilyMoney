using System;

namespace FamilyMoney.API.Models
{
    public class Family : BaseEntity
    {
        private Family(string name, string user) : base(user)
        {
            this.Name = name;
        }

        public string Name { get; private set; }         
    }
}