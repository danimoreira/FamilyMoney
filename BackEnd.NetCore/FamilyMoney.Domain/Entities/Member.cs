using System;

namespace FamilyMoney.API.Models
{
    public class Member : BaseEntity
    {
        public Member(Guid idFamily, string name, string user, string password, string role, string userCreate, string userUpdate)
            : base(userCreate)
        {
            IdFamily = idFamily;
            Name = name;
            User = user;
            Password = password;
            Role = role;
        }

        protected Member() { }

        public Guid IdFamily { get; private set; }
        public string Name { get; private set; }
        public string User { get; private set; }
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

    }
}