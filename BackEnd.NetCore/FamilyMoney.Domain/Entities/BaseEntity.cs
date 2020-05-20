using System;

namespace FamilyMoney.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity(string user)
        {           
            this.DateCreate = DateTime.Now;
            this.Active = true;
            this.UserCreate = user;            
        }

        public BaseEntity(){}

        public int Id { get; private set; }
        public DateTime DateCreate { get; private set; }
        public string UserCreate { get; private set; }
        public DateTime? DateLastUpdate { get; private set; }
        public string UserUpdate { get; private set; }
        public bool Active { get; private set; }

        public void Update(string userUpdate){
            this.UserUpdate = userUpdate;
            this.DateLastUpdate = DateTime.Now;
        }
    }
}