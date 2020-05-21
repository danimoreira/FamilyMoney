using System;

namespace FamilyMoney.Domain.Entities
{
    public class Member : BaseEntity
    {
        public Member(int idFamily, string name, string user, string password, string role, string userCreate)
            : base(userCreate)
        {
            IdFamily = idFamily;
            Name = name;
            Username = user;
            Password = password;
            Role = role;
        }

        protected Member() { }

        public int IdFamily { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == this.Password)
            {
                this.Password = newPassword;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(int idFamily, string name, string role, string userUpdate)
        {
            this.IdFamily = idFamily;
            this.Name = name;
            this.Role = role;
            base.Update(userUpdate);
        }

    }
}