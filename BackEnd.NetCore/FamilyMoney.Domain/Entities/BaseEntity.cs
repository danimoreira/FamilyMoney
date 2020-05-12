using System;

namespace FamilyMoney.API.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity(string user)
        {
            this.Id = Guid.NewGuid();
            this.DateCreate = DateTime.Now;
            this.Active = true;
            this.UserCreate = user;            
        }

        protected BaseEntity(){}

        public Guid Id { get; private set; }
        public DateTime DateCreate { get; private set; }
        public string UserCreate { get; private set; }
        public DateTime DateLastUpdate { get; private set; }
        public string UserUpdate { get; private set; }
        public bool Active { get; private set; }
    }
}